using System;
using System.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ponyform.Event;
using Ponyform.UI;
using Ponyform.Utilities;

namespace Ponyform.Game.View {
    public class Pony: GameObject {
        // References
        private AssetManager _am;
        public CollisionBox mouthBox, hairBox, tailBox;
        private readonly EventManager _em;
        
        // View
        private Image pony_mid;
        private Image pony_hair_back, pony_hair_front;
        private Image pony_tail;
        private AnimatedImage ponyMouth;
        private PonyEyes eyes;

        // Current State
        private PonyData _currentData, _targetData;

        public Pony(){
            _am = DI.Get<AssetManager>();
            _em = DI.Get<EventManager>();

            CreateView();
            ArrangeView();
            RegisterListeners();
        }

        private void CreateView(){
            pony_mid = new Image(_am.pony_mid);
            ponyMouth = new AnimatedImage(_am.pony_mouth_1, _am.pony_mouth_2, _am.pony_mouth_3);
            eyes = new PonyEyes();
            
            AddAll(pony_mid, ponyMouth, eyes);
            
            var scale = gameInfra.scale;
            mouthBox = new CollisionBox(new Vector2(scale*100));
            hairBox = new CollisionBox(new Vector2(scale*100));
            tailBox = new CollisionBox(new Vector2(scale*100));
            
            AddAll(mouthBox, hairBox, tailBox);
        }

        private void ArrangeView(){
            SetSize(pony_mid.size);
            eyes.SetPosition(0.05f*gameInfra.GetGameWidth(), 0.123f*gameInfra.GetGameHeight());
            
            var scale = gameInfra.scale;
            mouthBox.SetPosition(size.X * 0.3f, size.Y*0.25f);
            hairBox.SetPosition(0, 0);
            tailBox.SetPosition(size.X*0.6f, size.Y*0.4f);
            
            // mouthBox.debug = true;
            // hairBox.debug = true;
            // tailBox.debug = true;
        }

        private void RegisterListeners(){
            _em.RegisterListener(GameEvent.StartedEating, OnEatingBegin);
            _em.RegisterListener(GameEvent.StoppedEating, OnEatingEnd);
            _em.RegisterListener(GameEvent.StartedGrooming, OnGroomingBegin);
            _em.RegisterListener(GameEvent.StoppedGrooming, OnPartGroomed);
        }

        public override void Update(GameTime gameTime){
            // Update pony's colors
            base.Update(gameTime);
        }

        #region Pony View Updates
        private void UpdatePonyUsingData(){
            
        }
        
        
        #endregion
        
        #region Event Handlers

        public void OnEatingBegin(object data){
            if (!Utils.TryConvertVal(data, out EatingInfo info)){
                return;
            }
            Logger.i("Pony", $"Started Eating, food = {info.foodItem }");
            ponyMouth.Play(4, 100);
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

        private void OnEatingEnd(object data)
        {
            Logger.i("Pony", "Stopped Eating");
            ponyMouth.Reset();
        }

        private void OnGroomingBegin(object data)
        {
            if (!Utils.TryConvertVal(data, out GroomInfo info)){
                return;
            }
            Logger.i("Pony", $"Grooming Started, part = {info.groomPart}");
        }
        
        private void OnPartGroomed(object data)
        {
            Logger.i("Pony", "Grooming Ended");
        }
        #endregion


    }
}