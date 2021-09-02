using System;
using System.Collections.Generic;
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
        private Image ponyMouth;
        private PonyEyes eyes;

        // Current State
        private PonyData _currentData, _targetData;
        private Dictionary<PonyTailStyle, List<Texture2D>> tailTextures;

        public Pony(){
            _am = DI.Get<AssetManager>();
            _em = DI.Get<EventManager>();

            _currentData = new PonyData();
            _targetData = new PonyData();
            generateTextureMaps();
            CreateView();
            ArrangeView();
            RegisterListeners();
        }

        private void generateTextureMaps() {
            tailTextures = new Dictionary<PonyTailStyle, List<Texture2D>> {
                {PonyTailStyle.Default, new List<Texture2D>{_am.pony_tail0}},
                {PonyTailStyle.TailStyle1, new List<Texture2D>{_am.pony_tail1}},
                {PonyTailStyle.TailStyle2, new List<Texture2D>{_am.pony_tail2}},
                {PonyTailStyle.TailStyle3, new List<Texture2D>{_am.pony_tail3}},
                {PonyTailStyle.TailStyle4, new List<Texture2D>{_am.pony_tail4}},
                {PonyTailStyle.TailStyle5, new List<Texture2D>{_am.pony_tail5}},
            };
        }

        private void CreateView(){
            pony_mid = new Image(_am.pony_mid);
            ponyMouth = new Image(_am.pony_mouth_1, _am.pony_mouth_2, _am.pony_mouth_3);
            pony_hair_back = new Image(_am.pony_hair0_back);
            pony_hair_front = new Image(_am.pony_hair0_front);
            pony_tail = new Image(_am.pony_tail0);
            eyes = new PonyEyes();
            
            AddAll(pony_hair_back, pony_tail, pony_mid, pony_hair_front, ponyMouth, eyes);
            
            var scale = gameInfra.scale;
            mouthBox = new CollisionBox(new Vector2(scale*100));
            hairBox = new CollisionBox(new Vector2(scale*100));
            tailBox = new CollisionBox(new Vector2(scale*100));
            
            AddAll(mouthBox, hairBox, tailBox);
        }

        private void ArrangeView(){
            SetSize(pony_mid.size);
            ponyMouth.SetPosition(0.37f*size.X, 0.32f*size.Y);
            ponyMouth.SetVisibility(false);

            UpdateHairTexturesForPony();
            UpdateTailTexturesForPony();
            eyes.SetPosition(0.05f*gameInfra.GetGameWidth(), 0.123f*gameInfra.GetGameHeight());
            
            // Collision boxes
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

        private void UpdateHairTexturesForPony() {
            Vector2 back_ratio, front_ratio;
            switch (_currentData.hairStyle) {
                case PonyHairStyle.Default:
                    back_ratio = new Vector2(-0.08f, 0.056f);
                    front_ratio = new Vector2(0.135f, 0.036f);
                    pony_hair_back.UpdateTextures(_am.pony_hair0_back);
                    pony_hair_front.UpdateTextures(_am.pony_hair0_front);
                    break;
                case PonyHairStyle.HairStyle1:
                    back_ratio = new Vector2(-0.56f, 0.023f);
                    front_ratio = new Vector2(0.135f, 0.036f);
                    pony_hair_back.UpdateTextures(_am.pony_hair1_back);
                    pony_hair_front.UpdateTextures(_am.pony_hair1_front);
                    break;
                case PonyHairStyle.HairStyle2:
                    back_ratio = new Vector2(-0.25f, 0.054f);
                    front_ratio = new Vector2(0.135f, 0.036f);
                    pony_hair_back.UpdateTextures(_am.pony_hair2_back);
                    pony_hair_front.UpdateTextures(_am.pony_hair2_front);
                    break;
                case PonyHairStyle.HairStyle3:
                    back_ratio = new Vector2(-0.384f, 0.054f);
                    front_ratio = new Vector2(0.135f, 0.036f);
                    pony_hair_back.UpdateTextures(_am.pony_hair3_back);
                    pony_hair_front.UpdateTextures(_am.pony_hair3_front);
                    break;
                case PonyHairStyle.HairStyle4:
                    back_ratio = new Vector2(-0.343f, 0.039f);
                    front_ratio = new Vector2(0.135f, 0.036f);
                    pony_hair_back.UpdateTextures(_am.pony_hair4_back);
                    pony_hair_front.UpdateTextures(_am.pony_hair4_front);
                    break;
                case PonyHairStyle.HairStyle5:
                    back_ratio = new Vector2(-0.243f, 0.042f);
                    front_ratio = new Vector2(0.135f, 0.036f);
                    pony_hair_back.UpdateTextures(_am.pony_hair5_back);
                    pony_hair_front.UpdateTextures(_am.pony_hair5_front);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            pony_hair_back.SetPosition(back_ratio.X*size.X, back_ratio.Y*size.Y);
            pony_hair_front.SetPosition(front_ratio.X*size.X, front_ratio.Y*size.Y);
        }

        private void UpdateTailTexturesForPony() {
            var (x, y) = new Vector2(0.767f, 0.386f);
            var tex = tailTextures.GetValueOrDefault(_currentData.tailStyle, new List<Texture2D>{_am.pony_tail0});
            pony_tail.UpdateTextures(tex.ToArray());
            pony_tail.SetPosition(x*size.X, y*size.Y);
        }
        
        #endregion
        
        #region Event Handlers

        public void OnEatingBegin(object data){
            if (!Utils.TryConvertVal(data, out EatingInfo info)){
                return;
            }
            Logger.i("Pony", $"Started Eating, food = {info.foodItem }");
            ponyMouth.SetVisibility(true);
            ponyMouth.Play(4, 3);
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
            ponyMouth.SetVisibility(false);
        }

        private void OnGroomingBegin(object data)
        {
            if (!Utils.TryConvertVal(data, out GroomInfo info)){
                return;
            }
            Logger.i("Pony", $"Grooming Started, part = {info.groomPart}, hairStyle = {info.ponyHairStyle}, tailStyle = {info.ponyTailStyle}");
        }
        
        private void OnPartGroomed(object data)
        {
            Logger.i("Pony", "Grooming Ended");
        }
        #endregion


    }
}