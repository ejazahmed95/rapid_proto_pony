using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ponyform.Utilities;

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
            Logger.i("GM", "Game initialized");
            spriteBatch = gameInfra.SpriteBatch;
            Enabled = true;
        }

        public override void Draw(GameTime gameTime){
            Logger.i("GM", "Game manager drawing content");
            spriteBatch.Begin();
            spriteBatch.Draw(assetManager.pony_basic, new Vector2(20,20), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}