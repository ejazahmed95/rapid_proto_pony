using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ponyform.Event;
using Ponyform.UI;
using Ponyform.Utilities;

namespace Ponyform.Game.View {
    public class Pony: GameObject {
        // References
        private AssetManager _am;
        private GameInfra _gameInfra;
        
        private Image pony_mid;
        private PonyEyes eyes;
        private readonly EventManager _em;

        public CollisionBox mouthBox, hairBox, tailBox;
        // Current State

        public Pony(){
            _am = DI.Get<AssetManager>();
            _em = DI.Get<EventManager>();
            var infra = DI.Get<GameInfra>();

            pony_mid = new Image(_am.pony_mid);
            Add(pony_mid);
            
            eyes = new PonyEyes();
            eyes.SetPosition(0.05f*infra.GetGameWidth(), 0.123f*infra.GetGameHeight());
            Add(eyes);
            CreateView();
            ArrangeView();
            _em.RegisterListener(GameEvent.StartedEating, OnFeedButtonClick);
            _em.RegisterListener(GameEvent.StoppedEating, onStoppedEating);

            _em.RegisterListener(GameEvent.StartedGrooming, onStartedGrooming);
            _em.RegisterListener(GameEvent.StoppedGrooming, onStoppedGrooming);


            // _em.SendEvent(GameEvent.Feed_Button_Clicked, new EatingInfo{foodItem = Food.Milk});
        }

        private void CreateView(){
            var scale = gameInfra.scale;
            mouthBox = new CollisionBox(new Vector2(scale*100));
            hairBox = new CollisionBox(new Vector2(scale*100));
            tailBox = new CollisionBox(new Vector2(scale*100));
            
            AddAll(mouthBox, hairBox, tailBox);
        }

        private void ArrangeView(){
            SetSize(pony_mid.size);
            var scale = gameInfra.scale;
            mouthBox.SetPosition(size.X * 0.3f, size.Y*0.25f);
            hairBox.SetPosition(0, 0);
            tailBox.SetPosition(size.X*0.6f, size.Y*0.4f);
            
            mouthBox.debug = true;
            hairBox.debug = true;
            tailBox.debug = true;
        }

        #region Event Handlers

        public void OnFeedButtonClick(object data){
            if (!Utils.TryConvertVal(data, out EatingInfo info)){
                return;
            }
            Logger.i("Pony", $"Started Eating, food = {info.foodItem }");
            switch (info.foodItem){
                case Food.Apple:
                    eyes.Blink(1);
                    break;
                case Food.Milk:
                    eyes.Blink(2);
                    break;
                case Food.Grass:
                    eyes.Blink(3);
                    break;
                default:
                    break;
            }
        }

        private void onStoppedEating(object data)
        {
            Logger.i("Pony", "Stopped Eating");
        }

        private void onStartedGrooming(object data)
        {
            if (!Utils.TryConvertVal(data, out GroomInfo info))
            {
                return;
            }
            Logger.i("Pony", $"Started Grooming, food = {info.groomPart}");
        }

        private void onStoppedGrooming(object data)
        {
            if (!Utils.TryConvertVal(data, out GroomInfo info))
            {
                return;
            }
            Logger.i("Pony", $"Stopped Grooming, food = {info.groomPart}");
        }

        #endregion


    }
}