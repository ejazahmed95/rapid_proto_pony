using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ponyform.Game
{
    public class GameManager: DrawableGameComponent {
        private GameInfra gameInfra;
        private AssetManager assetManager;
        private SpriteBatch spriteBatch;
        
        public GameManager(Microsoft.Xna.Framework.Game game) : base(game){
            gameInfra = DI.Get<GameInfra>();
            assetManager = DI.Get<AssetManager>();
        }

        public void OnGameInit(){
            spriteBatch = gameInfra.spriteBatch;
        }

        public override void Draw(GameTime gameTime){
            spriteBatch.Begin();
            spriteBatch.Draw(assetManager.pony_basic, Vector2.Zero, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}