using Microsoft.Xna.Framework.Graphics;

namespace Ponyform.Game
{
    public class GameInfra {
        public SpriteBatch spriteBatch;
        
        public GameInfra(){
        }

        public void Load(GraphicsDevice graphicsDevice){
            spriteBatch = new SpriteBatch(graphicsDevice);
        }
    }
}