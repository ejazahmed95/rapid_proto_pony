using Ponyform.Event;
using Ponyform.UI;

namespace Ponyform.Game.View {
    public class ActivityBar: GameObject {
        private AssetManager _am;
        private EventManager _em;

        private Image bg;
        private Button feed, groom;
        
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
        }

        private void onFeedClick(){
            
        }
        private void onGroomClick(){
            
        }
    }
}