﻿using System;
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

            _em.RegisterListener(GameEvent.ActivitySet, OnFeedButtonClick);
            
            // _em.SendEvent(GameEvent.Feed_Button_Clicked, new EatingInfo{foodItem = Food.Milk});
        }

        #region Event Handlers

        public void OnFeedButtonClick(object data){
            if (!Utils.TryConvertVal(data, out EatingInfo info)){
                return;
            }

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

        #endregion


    }
}