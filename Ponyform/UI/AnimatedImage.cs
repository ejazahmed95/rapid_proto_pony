using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using Ponyform.Game;

namespace Ponyform.UI {
    public class AnimatedImage: GameObject {
        private List<Texture2D> _textures;
        private Color _color = Color.White;
        private float scale;
        
        // Current State
        private int currentIndex = 0;
        private Texture2D _currentTex;
        
        // Animation
        private bool isPlaying = false;
        private int maxLoops = 1;
        private int currentLoop = 1;
        private float currentIndexFloat = 0;
        private float speed = 60;
        

        public AnimatedImage(params Texture2D[] textures){
            scale = DI.Get<GameInfra>().scale;
            _textures = textures.ToList();
            _currentTex = _textures[0];
            
            SetWidth(_textures[0].Width*scale);
            SetHeight(_textures[0].Height*scale);
        }

        public override void Update(GameTime gameTime){
            if (isPlaying){
                currentIndexFloat += gameTime.GetElapsedSeconds() * speed;
                if (currentIndexFloat > _textures.Count){
                    currentLoop++;
                    currentIndexFloat -= _textures.Count;
                }

                currentIndex = (int) currentIndexFloat;
                if (currentLoop > maxLoops){
                    Reset();
                }
            }
            base.Update(gameTime);
        }

        public void Play(int fps, int loops = 1){
            speed = fps;
            maxLoops = loops;
            isPlaying = true;
        }

        public void Reset(){
            maxLoops = 1;
            currentLoop = 1;
            currentIndexFloat = 0;
            currentIndex = 0;
            isPlaying = false;
        }

        public override void Draw(SpriteBatch batch, Vector2 origin){
            batch.Draw(_textures[currentIndex], pos + origin, null, _color, 0, new Vector2(), scale, 0, 0);
            base.Draw(batch, origin);
        }
    }
}