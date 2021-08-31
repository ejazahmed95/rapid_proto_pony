using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ponyform.Event;
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

        private ActivityBar aBar;

        private FoodBar foodBar;
        // private readonly EventManager eventManager;

        public GameManager(){ 
            gameInfra = DI.Get<GameInfra>();
            assetManager = DI.Get<AssetManager>();
            // eventManager = DI.Get<EventManager>();
            gameRoot = new EmptyGameObject();
        }

        public void OnGameInit(){
            Logger.i("GM", "Game initialized");
            spriteBatch = gameInfra.SpriteBatch;
            DI.Register(env = new Environment());
            DI.Register(pony = new Pony());

            createView();
            arrangeView();
        }

        private void createView() {
            this.aBar = new ActivityBar();
            this.foodBar = new FoodBar();
            // Add to Gameroot
            gameRoot.Add(env);
            gameRoot.Add(pony);
            gameRoot.Add(aBar);
            gameRoot.Add(foodBar);
        }

        private void arrangeView() {
            pony.SetPosition(gameInfra.GetGameWidth()*0.4f, gameInfra.GetGameHeight()*0.25f);
            aBar.SetPosition(gameInfra.GetGameWidth(), 0, Alignment.TOP_RIGHT);
            foodBar.SetPosition(0, gameInfra.GetGameHeight(), Alignment.BOTTOM_LEFT);
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