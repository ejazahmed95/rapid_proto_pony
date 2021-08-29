using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ponyform.Game
{
    public class GameInfra {
        public SpriteBatch SpriteBatch;
        private const int GameWidth = 1920;
        private const int GameHeight = 1080;
        public float scale = 0.6f;
        private GraphicsDeviceManager _graphics;

        public float GetGameHeight(){
            return GameHeight * scale;
        }
        
        public float GetGameWidth(){
            return GameWidth * scale;
        }
        
        public GameInfra(Microsoft.Xna.Framework.Game ponyGame){
            _graphics = new GraphicsDeviceManager(ponyGame);
            
            // spriteBatch = new SpriteBatch(_graphics.GraphicsDevice);
        }

        public void Load(){
            _graphics.PreferredBackBufferWidth = (int)(GameWidth * scale);
            _graphics.PreferredBackBufferHeight = (int)(GameHeight * scale);
            _graphics.ApplyChanges();
            
            SpriteBatch = new SpriteBatch(_graphics.GraphicsDevice);
        }
    }
}