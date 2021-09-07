using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using Ponyform.Event;
using Ponyform.UI;
using Ponyform.Utilities;
using System.Collections.Generic;

namespace Ponyform.Game.View {
    public class GroomBar: MoveableIcon {
        private AssetManager _am;
        private EventManager _em;
        private GestureManager _gm;

        //private Image bg;
        private DraggableIcon brush, comb, curlingIron;

        private int _horizontalAmount = 0;
        private int _verticalAmount = 0;

        private bool _preHoldingBrush = false, _preHoldingComb = false;

        private int hairStyle = 0;
        private int tailStyle = 0;

        private bool _preReached = false;
        private bool _visGoal = false;

        private Vector2 _enabledPos;
        private Vector2 _disabledPos;

        private Gesture gesture;
        
        public GroomBar(Texture2D texture) : base(texture)
        {
            _am = DI.Get<AssetManager>();
            _em = DI.Get<EventManager>();
            _gm = DI.Get<GestureManager>();
            createView();
            arrangeView();
            _em.RegisterListener(GameEvent.ActivitySet, onActivitySet);
        }

        private void createView() {
            //bg = new Image(_am.groom_bottom_bg);
            brush = new DraggableIcon(_am.groom_brush);
            comb = new DraggableIcon(_am.groom_comb);
            curlingIron = new DraggableIcon(_am.groom_curling_iron);

            //Test code for gesture
            //if (gesture == null) gesture = new Gesture(_gm.setStyle(hairGroom, GroomPart.Hair, 0));
            //Add(gesture);

            if (gesture == null)
            {
                gesture = new Gesture(_gm.setStyle(curlingIron, GroomPart.Hair, -1), true);
                Add(gesture);
            }

            AddAll(curlingIron, comb, brush);

            _horizontalAmount += 3;
            _verticalAmount += 1;
        }

        private void arrangeView() {
            float xPos = 0, yPos = 0;
            float iconWidth = size.X / (_horizontalAmount + 1);
            float iconHeight = size.Y / (_verticalAmount + 1);

            float biasHeight = - size.Y * 0.7f;

            yPos += biasHeight;

            xPos += iconWidth;
            yPos += iconHeight;

            curlingIron.SetPosition(xPos, yPos);
            xPos += iconWidth;
            comb.SetPosition(xPos, yPos);
            xPos += iconWidth;
            brush.SetPosition(xPos, yPos);

            SetSize(new Vector2(size.X, size.Y));
            SetVisibility(false);
        }
        
        private void onActivitySet(object data){
            if (!Utils.TryConvertVal(data, out ActivitySelectInfo info)){
                return;
            }
            Logger.i("GroomBar", $"Activity Set = {info.type}");

            _preReached = false;

            if (_visGoal != (info.type == ActivityType.GROOM))
            {
                _visGoal = (info.type == ActivityType.GROOM);
                if (_visGoal)
                {
                    Logger.d("groombar", $"set{_visGoal}");
                    SetVisibility(_visGoal);
                    MoveTo(_enabledPos);
                }
                else MoveTo(_disabledPos);
            }
        }

        public void SetIfEnabledPossition(Vector2 pos1, Vector2 pos2)
        {
            _enabledPos = pos1;
            _disabledPos = pos2;
        }

        public override void Update(GameTime gameTime)
        {
            if (_preReached == false && _reached == true)
            {
                if (!_visGoal)
                {
                    Logger.d("groombar", $"set{_visGoal}");
                    SetVisibility(_visGoal);
                }
            }

            //Test code for gesture
            //if (gesture.Over) gesture.ResetGesture(_gm.setStyle(hairGroom, GroomPart.Hair, 1));

            if (curlingIron.Holding)
            {
                if (!_preHoldingBrush)
                {
                    if (gesture.Over) gesture.ResetGesture(_gm.setStyle(curlingIron, GroomPart.Hair, hairStyle++ % 5), false);
                    _preHoldingBrush = true;
                }
            }
            else
            {
                if (_preHoldingBrush)
                {
                    gesture.ResetGesture(_gm.setStyle(curlingIron, GroomPart.Hair, -1), true);
                    Logger.d("GroomBar", "destory the gesture");
                    _preHoldingBrush = false;
                }
            }

            if (comb.Holding)
            {
                if (!_preHoldingComb)
                {
                    if (gesture.Over) gesture.ResetGesture(_gm.setStyle(comb, GroomPart.Tail, tailStyle++ % 5), false);
                    _preHoldingComb = true;
                }
            }
            else
            {
                if (_preHoldingComb)
                {
                    gesture.ResetGesture(_gm.setStyle(curlingIron, GroomPart.Tail, -1), true);
                    Logger.d("GroomBar", "destory the gesture");
                    _preHoldingComb = false;
                }
            }

            base.Update(gameTime);
        }
    }
}