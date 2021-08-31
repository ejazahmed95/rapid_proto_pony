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
        }

        private void arrangeView(){
            groom.SetPosition(0, 100);
            
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