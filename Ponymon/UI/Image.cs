using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Ponyform.UI {
    public class Image: GameObject {
        private Texture2D _tex;
        protected Color _color = Color.White;
        private float scale = 1f;
        
        private List<Texture2D> _textures;
        public Rectangle Rectangle => new Rectangle((int)globalPosition.X, (int)globalPosition.Y, (int)size.X, (int)size.Y);
        
        // Current State
        private int currentIndex = 0;
        
        // Animation
        private bool isPlaying = false;
        private int maxLoops = 1;
        private int currentLoop = 1;
        private float currentIndexFloat = 0;
        private float speed = 60;
        
        public Image(Texture2D texture){
            _textures = new List<Texture2D> {texture};
            
            SetWidth(_textures[0].Width*scale*gameInfra.scale);
            SetHeight(_textures[0].Height*scale*gameInfra.scale);
        }
        
        public Image(params Texture2D[] textures) {
            _textures = textures.ToList();

            SetWidth(_textures[0].Width*scale*gameInfra.scale);
            SetHeight(_textures[0].Height*scale*gameInfra.scale);
        }

        public void SetScale(float scale){
            this.scale = scale;
        }

        public void UpdateTextures(params Texture2D[] textures) {
            _textures = textures.ToList();
            Reset();
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

        public void SetColor(Color color)
        {
            _color = color;
        }

        public override void Draw(SpriteBatch batch, Vector2 origin){
            batch.Draw(_textures[currentIndex], pos + origin, null, _color, 0, new Vector2(), scale*gameInfra.scale, 0, 0);
            base.Draw(batch, origin);
        }

    }
}