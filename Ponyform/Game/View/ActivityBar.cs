using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ponyform.Event;
using Ponyform.UI;
using Ponyform.Utilities;

namespace Ponyform.Game.View {
    public class ActivityBar: MoveableIcon {
        private AssetManager _am;
        private EventManager _em;

        //private Image bg;
        private Button feed, groom;

        private Button arrow;

        private ActivityType _currentActivity = ActivityType.NONE;

        private int _horizontalAmount = 0;
        private int _verticalAmount = 0;

        private bool _visGoal = false;

        private Vector2 _enabledPos;
        private Vector2 _disabledPos;

        public ActivityBar(Texture2D texture) : base(texture) {
            _am = DI.Get<AssetManager>();
            _em = DI.Get<EventManager>();

            createView();
            arrangeView();
        }

        private void createView(){
            //bg = new Image(_am.button_side_bg);
            feed = new Button(_am.button_feed, OnFeedClick);
            groom = new Button(_am.button_groom, OnGroomClick);
            arrow = new Button(_am.arrow_bottom, OnArrowClick);
            AddAll(feed, groom, arrow);

            _horizontalAmount += 1;
            _verticalAmount += 2;
        }

        private void arrangeView(){
            float xPos = 0, yPos = 0;

            arrow.SetPosition(xPos - size.X * 0.025f, yPos + size.Y / 2);

            float leftAlignmentPosition = size.X * 0.3f;
            float iconHeight = size.Y / (_verticalAmount + 1);

            xPos += leftAlignmentPosition;
            yPos += iconHeight;

            feed.SetPosition(xPos, yPos, Alignment.LEFT);
            yPos += iconHeight;
            groom.SetPosition(xPos, yPos, Alignment.LEFT);
            
            SetSize(new Vector2(size.X, size.Y));
        }

        private void OnFeedClick() {
            Logger.i("ActivityBar", "Feed button clicked!");
            if (_currentActivity == ActivityType.FEED) {
                ClearActivity();
                return;
            }
            _currentActivity = ActivityType.FEED;
            SendActivitySelectEvent();
        }
        
        private void OnGroomClick(){
            Logger.i("ActivityBar", "Groom button clicked!");
            if (_currentActivity == ActivityType.GROOM) {
                ClearActivity();
                return;
            }
            _currentActivity = ActivityType.GROOM;
            SendActivitySelectEvent();
        }

        private void OnArrowClick()
        {
            if (!_visGoal)
            {
                _visGoal = true;
                MoveTo(_enabledPos);
            }
            else
            {
                _visGoal = false;
                MoveTo(_disabledPos);
            }
        }

        public void SetIfEnabledPossition(Vector2 pos1, Vector2 pos2)
        {
            _enabledPos = pos1;
            _disabledPos = pos2;
        }

        private void ClearActivity() {
            _currentActivity = ActivityType.NONE;
            SendActivitySelectEvent();
        }

        private void SendActivitySelectEvent(){
            _em.SendEvent(GameEvent.ActivitySet, new ActivitySelectInfo{type = _currentActivity});
        }
    }
}