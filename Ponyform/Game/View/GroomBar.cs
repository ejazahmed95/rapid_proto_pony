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
        private DraggableIcon brush, comb, curlingIron;

        private bool _preHoldingBrush = false, _preHoldingComb = false;

        private int hairStyle = 0;
        private int tailStyle = 0;

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
            bg = new Image(_am.groom_bottom_bg);
            brush = new DraggableIcon(_am.groom_brush);
            comb = new DraggableIcon(_am.groom_comb);
            curlingIron = new DraggableIcon(_am.groom_curling_iron);

            //Test code for gesture
            //if (gesture == null) gesture = new Gesture(_gm.setStyle(hairGroom, GroomPart.Hair, 0));
            //Add(gesture);

            if (gesture == null)
            {
                gesture = new Gesture(_gm.setStyle(brush, GroomPart.Hair, -1));
                Add(gesture);
                gesture.Over = true;
            }

            AddAll( bg, brush, comb, curlingIron);
        }

        private void arrangeView() {
            float xPos = 0, yPos = 0, iconWidth = 100f;
            brush.SetPosition(xPos, yPos);
            xPos += iconWidth;
            comb.SetPosition(xPos, yPos);
            xPos += iconWidth;

            curlingIron.SetPosition(xPos, yPos);

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
            //if (gesture.Over) gesture.ResetGesture(_gm.setStyle(hairGroom, GroomPart.Hair, 1));

            if (brush.Holding)
            {
                if (!_preHoldingBrush)
                {
                    if (gesture.Over) gesture.ResetGesture(_gm.setStyle(brush, GroomPart.Hair, hairStyle++ % 5));
                    _preHoldingBrush = true;
                }
            }
            else
            {
                if (_preHoldingBrush)
                {
                    _preHoldingBrush = false;
                }
            }

            if (comb.Holding)
            {
                if (!_preHoldingComb)
                {
                    if (gesture.Over) gesture.ResetGesture(_gm.setStyle(comb, GroomPart.Tail, tailStyle++ % 5));
                    _preHoldingComb = true;
                }
            }
            else
            {
                if (_preHoldingComb)
                {
                    _preHoldingComb = false;
                }
            }

            base.Update(gameTime);
        }
    }
}