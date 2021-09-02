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

        private Image bg;
        private DraggableIcon hairGroom, tailGroom;

        private Gesture gesture;
        
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


            //test code for gesture
            //List<Vector2> gesturePositions = new List<Vector2>();
            //gesturePositions.Add(new Vector2(250, 0));
            //gesturePositions.Add(new Vector2(500, 0));
            //gesturePositions.Add(new Vector2(500, 250));
            //gesturePositions.Add(new Vector2(250, 250));

            //gesture = new Gesture(_am.star, gesturePositions, new Vector2(10, 10), hairGroom);
            //gesture.SetPosition(200, -400);
            //gesture.NextColor = new Color(0, 0, 0);
            //gesture.RegisterCollider(() => _em.SendEvent(GameEvent.StartedGrooming, new GroomInfo { groomPart = GroomPart.Hair }), 
            //    () => _em.SendEvent(GameEvent.StoppedGrooming, new GroomInfo { groomPart = GroomPart.Hair }));



            AddAll( bg, hairGroom, tailGroom, gesture);
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