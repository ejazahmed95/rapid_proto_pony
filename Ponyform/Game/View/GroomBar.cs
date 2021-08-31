using Microsoft.Xna.Framework;
using MonoGame.Extended;
using Ponyform.Event;
using Ponyform.UI;
using Ponyform.Utilities;

namespace Ponyform.Game.View {
    public class GroomBar: GameObject {
        private AssetManager _am;
        private EventManager _em;

        private Image bg;
        private DraggableIcon hairGroom, tailGroom;
        
        public GroomBar(){
            _am = DI.Get<AssetManager>();
            _em = DI.Get<EventManager>();
            createView();
            arrangeView();
            _em.RegisterListener(GameEvent.ActivitySet, onActivitySet);
        }

        private void createView() {
            bg = new Image(_am.button_bottom_bg);
            hairGroom = new DraggableIcon(_am.ball);
            tailGroom = new DraggableIcon(_am.ball);

            AddAll( bg, hairGroom, tailGroom);
        }

        private void arrangeView() {
            float xPos = 0, yPos = 0, iconWidth = 100f;
            hairGroom.SetPosition(xPos, yPos);
            xPos += iconWidth;
            tailGroom.SetPosition(xPos, yPos);
            xPos += iconWidth;

            SetSize(new Vector2(bg.size.X, bg.size.Y));
            SetVisibility(false);
        }
        
        private void onActivitySet(object data){
            if (!Utils.TryConvertVal(data, out ActivitySelectInfo info)){
                return;
            }
            Logger.i("GroomBar", $"Activity Set = {info.type}");
            SetVisibility(info.type == ActivityType.GROOM);
        }
    }
}