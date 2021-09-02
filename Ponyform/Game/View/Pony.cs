using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
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

        // Dialogue Manager
        private DialogManager dm;
        
        // Current State
        private PonyData _currentData, _targetData;
        private Dictionary<PonyTailStyle, List<Texture2D>> tailTextures;
        private int _currentFrames = 0;

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
            
            dm = new DialogManager();
            Add(dm);
            
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

            // _targetData.bodyColor = new Color(new Vector3(0.5f, 0.1f, 0.1f));
            UpdateHairTexturesForPony();
            UpdateTailTexturesForPony();
            eyes.SetPosition(0.05f*gameInfra.GetGameWidth(), 0.123f*gameInfra.GetGameHeight());
            
            dm.SetPosition(size.X/2, 0, Alignment.BOTTOM);
            
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
            if (!_currentData.bodyColor.Equals(_targetData.bodyColor)){
                this._currentFrames++;
                if (_currentFrames >= 10){
                    _currentData.bodyColor = interpolate(_currentData.bodyColor.ToVector3(), _targetData.bodyColor.ToVector3(),
                        gameTime.GetElapsedSeconds(), 3);
                    pony_mid.SetColor(_currentData.bodyColor);
                    _currentFrames = 0;
                }
            } else{
                _currentFrames = 0;
            }
            base.Update(gameTime);
        }

        private Color interpolate(Vector3 current, Vector3 target, float elapsedSec, int i){
            Vector3 res = new Vector3(current.X, current.Y, current.Z);
            float max = (1f / i) * elapsedSec;
            Logger.i("INTERPOLATE", $"{current}  {target}  {elapsedSec}  {i} {max}");
            res.X = moveTowards(res.X, target.X, max);
            res.Y = moveTowards(res.Y, target.Y, max);
            res.Z = moveTowards(res.Z, target.Z, max);
            return new Color(res);
        }

        private float moveTowards(float current, float target, float max){
            if (Math.Abs(target - current) < max){
                return target;
            }

            if (target < current){
                // Logger.i("INTERPOLATE2", $"{target} {current} {max}");
                return current - max;
            }
            // Logger.i("INTERPOLATE3", $"{target} {current} {max}");
            return current + max;
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
            ponyMouth.Play(4, 50);
            dm.showDialogue(info.foodItem);
            eyes.Blink(1);
            switch (info.foodItem){
                case Food.Apple:
                    _targetData.bodyColor = Color.Red;
                    break;
                case Food.Milk:
                    _targetData.bodyColor = Color.White;
                    break;
                case Food.Grass:
                    _targetData.bodyColor = Color.Green;
                    break;
                case Food.Blueberry:
                    _targetData.bodyColor = Color.Blue;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void OnEatingEnd(object data)
        {
            Logger.i("Pony", "Stopped Eating");
            _targetData.bodyColor = new Color(_currentData.bodyColor.ToVector3());
            ponyMouth.Reset();
            ponyMouth.SetVisibility(false);
            dm.hideDialogue();
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
            if (!Utils.TryConvertVal(data, out GroomInfo info)){
                return;
            }
            switch (info.groomPart) {
                case GroomPart.Hair:
                    _currentData.hairStyle = info.ponyHairStyle;
                    UpdateHairTexturesForPony();
                    break;
                case GroomPart.Body:
                    break;
                case GroomPart.Tail:
                    _currentData.tailStyle = info.ponyTailStyle;
                    UpdateTailTexturesForPony();
                    break;
                default:
                    break;
            }
            Logger.i("Pony", "Grooming Ended");
        }
        #endregion


    }
}