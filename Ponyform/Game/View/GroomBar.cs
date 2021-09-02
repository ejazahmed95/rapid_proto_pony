using Microsoft.Xna.Framework;
using MonoGame.Extended;
using Ponyform.Event;
using Ponyform.UI;
using Ponyform.Utilities;
using System.Collections.Generic;

namespace Ponyform.Game.View {
    public class GroomBar: GameObject {
        private AssetManager _am;
        private EventManager _em;
        private GestureManager _gm;

        private Image bg;
        private DraggableIcon hairGroom, tailGroom;

        private Gesture gesture;
        
        public GroomBar(){
            _am = DI.Get<AssetManager>();
            _em = DI.Get<EventManager>();
            _gm = DI.Get<GestureManager>();
            createView();
            arrangeView();
            _em.RegisterListener(GameEvent.ActivitySet, onActivitySet);
        }

        private void createView() {
            bg = new Image(_am.button_bottom_bg);
            hairGroom = new DraggableIcon(_am.ball);
            tailGroom = new DraggableIcon(_am.ball);

            //Test code for gesture
            //if (gesture == null) gesture = new Gesture(_gm.setStyle1(hairGroom, GroomPart.Hair));
            //Add(gesture);


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

        public override void Update(GameTime gameTime)
        {
            //Test code for gesture
            //if (gesture.Over) gesture.ResetGesture(_gm.setStyle2(hairGroom, GroomPart.Hair));

            base.Update(gameTime);
        }
    }
}