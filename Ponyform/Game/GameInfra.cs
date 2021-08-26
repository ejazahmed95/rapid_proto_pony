using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ponyform.Game
{
    public class GameInfra {
        public SpriteBatch SpriteBatch;
        public const int GameWidth = 960;
        public const int GameHeight = 540;
        private GraphicsDeviceManager _graphics;
        
        public GameInfra(Microsoft.Xna.Framework.Game ponyGame){
            _graphics = new GraphicsDeviceManager(ponyGame);
            
            // spriteBatch = new SpriteBatch(_graphics.GraphicsDevice);
        }

        public void Load(){
            _graphics.PreferredBackBufferWidth = GameWidth;
            _graphics.PreferredBackBufferHeight = GameHeight;
            _graphics.ApplyChanges();
            
            SpriteBatch = new SpriteBatch(_graphics.GraphicsDevice);
        }
    }
}