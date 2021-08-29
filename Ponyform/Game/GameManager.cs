using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ponyform.Game.View;
using Ponyform.UI;
using Ponyform.Utilities;

namespace Ponyform.Game
{
    public class GameManager {
        private GameInfra gameInfra;
        private AssetManager assetManager;
        private SpriteBatch spriteBatch;

        public GameObject gameRoot;
        private Environment env;
        private Pony pony;

        public GameManager(){ 
            gameInfra = DI.Get<GameInfra>();
            assetManager = DI.Get<AssetManager>();
            gameRoot = new EmptyGameObject();
        }

        public void OnGameInit(){
            Logger.i("GM", "Game initialized");
            spriteBatch = gameInfra.SpriteBatch;
            DI.Register(env = new Environment());
            DI.Register(pony = new Pony());
            
            // Add to Gameroot
            gameRoot.Add(env);
            gameRoot.Add(pony);
            
        }

        public void Update(GameTime gameTime){
            gameRoot.Update(gameTime);
        }
        public void Draw(GameTime gameTime){
            Logger.i("GM", "Game manager drawing content");
            spriteBatch.Begin();
            gameRoot.Draw(spriteBatch, Vector2.Zero);
            // spriteBatch.Draw(assetManager.pony_basic, new Vector2(20,20), Color.White);
            spriteBatch.End();
        }
    }
}