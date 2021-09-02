using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ponyform.Utilities;

namespace Ponyform.Game
{
    public class GameInfra {
        public SpriteBatch SpriteBatch;
        private const int GameWidth = 1920;
        private const int GameHeight = 1080;
        public float scale = .5f;
        private GraphicsDeviceManager _graphics;

        public Texture2D debugTexture;

        public GameInfra(Microsoft.Xna.Framework.Game ponyGame){
            _graphics = new GraphicsDeviceManager(ponyGame);
            // spriteBatch = new SpriteBatch(_graphics.GraphicsDevice);
        }

        public float GetGameHeight(){
            return GameHeight * scale;
        }

        public float GetGameWidth(){
            return GameWidth * scale;
        }

        public GraphicsDevice GetGraphicsDevice(){
            return _graphics.GraphicsDevice;
        }

        public void Load(){
            _graphics.PreferredBackBufferWidth = (int)(GameWidth * scale);
            _graphics.PreferredBackBufferHeight = (int)(GameHeight * scale);
            _graphics.ApplyChanges();
            
            SpriteBatch = new SpriteBatch(_graphics.GraphicsDevice);
            debugTexture = new Texture2D(_graphics.GraphicsDevice, 1, 1);
            debugTexture.SetData(new Color[] { Utils.debugColor });
        }
    }
}