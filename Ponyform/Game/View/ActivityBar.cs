using Microsoft.Xna.Framework;
using Ponyform.Event;
using Ponyform.UI;

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
            feed = new Button(_am.button_feed, onFeedClick);
            groom = new Button(_am.button_groom, onGroomClick);
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

        private void onFeedClick() {
            if (_currentActivity == ActivityType.FEED) {
                clearActivity();
                return;
            }
            _em.SendEvent(GameEvent.ActivitySet, new ActivitySelectInfo());
        }
        
        private void onGroomClick(){
            
        }

        private void clearActivity() {
            _currentActivity = ActivityType.NONE;
            _em.SendEvent(GameEvent.ActivityCleared, new object());
        }
    }
}