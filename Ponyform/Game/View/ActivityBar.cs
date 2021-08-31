using Microsoft.Xna.Framework;
using Ponyform.Event;
using Ponyform.UI;
using Ponyform.Utilities;

namespace Ponyform.Game.View {
    public class ActivityBar: GameObject {
        private AssetManager _am;
        private EventManager _em;

        private Image bg;
        private Button feed, groom;

        private ActivityType _currentActivity = ActivityType.NONE;

        private int _horizontalAmount = 0;
        private int _verticalAmount = 0;

        public ActivityBar(){
            _am = DI.Get<AssetManager>();
            _em = DI.Get<EventManager>();

            createView();
            arrangeView();
        }

        private void createView(){
            bg = new Image(_am.button_side_bg);
            feed = new Button(_am.button_feed, OnFeedClick);
            groom = new Button(_am.button_groom, OnGroomClick);
            AddAll(bg, feed, groom);

            _horizontalAmount += 1;
            _verticalAmount += 2;
        }

        private void arrangeView(){
            float xPos = 0, yPos = 0;
            float leftAlignmentPosition = bg.size.X * 0.3f;
            float iconHeight = bg.size.Y / (_verticalAmount + 1);

            xPos += leftAlignmentPosition;
            yPos += iconHeight;

            feed.SetPosition(xPos, yPos, Alignment.LEFT);
            yPos += iconHeight;
            groom.SetPosition(xPos, yPos, Alignment.LEFT);
            
            SetSize(new Vector2(bg.size.X, bg.size.Y));
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

        private void ClearActivity() {
            _currentActivity = ActivityType.NONE;
            SendActivitySelectEvent();
        }

        private void SendActivitySelectEvent(){
            _em.SendEvent(GameEvent.ActivitySet, new ActivitySelectInfo{type = _currentActivity});
        }
    }
}