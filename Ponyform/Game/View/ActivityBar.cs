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
        }

        private void arrangeView(){
            groom.SetPosition(0, 100);
            
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