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

        private MouseStateDetecter mouseStateDetecter;

        private ActivityBar aBar;

        private FoodBar foodBar;
        private GroomBar groomBar;
        // private readonly EventManager eventManager;

        public GameManager(){ 
            gameInfra = DI.Get<GameInfra>();
            assetManager = DI.Get<AssetManager>();
            // eventManager = DI.Get<EventManager>();
            DI.Register(new GestureManager());
            gameRoot = new EmptyGameObject();
        }

        public void OnGameInit(){
            Logger.i("GM", "Game initialized");
            spriteBatch = gameInfra.SpriteBatch;
            DI.Register(env = new Environment());
            DI.Register(pony = new Pony());

            DI.Register(mouseStateDetecter = new MouseStateDetecter());

            createView();
            arrangeView();
        }

        private void createView() {
            aBar = new ActivityBar();
            foodBar = new FoodBar();
            groomBar = new GroomBar();
            // Add to Gameroot
            gameRoot.Add(env);
            gameRoot.Add(pony);
            gameRoot.Add(aBar);
            gameRoot.Add(foodBar);
            gameRoot.Add(groomBar);

            groomBar.Add(mouseStateDetecter);
        }

        private void arrangeView() {
            pony.SetPosition(gameInfra.GetGameWidth()*0.4f, gameInfra.GetGameHeight()*0.25f);
            aBar.SetPosition(gameInfra.GetGameWidth(), 0, Alignment.TOP_RIGHT);
            foodBar.SetPosition(0, gameInfra.GetGameHeight(), Alignment.BOTTOM_LEFT);
            groomBar.SetPosition(0, gameInfra.GetGameHeight(), Alignment.BOTTOM_LEFT);
        }

        public void Update(GameTime gameTime){
            gameRoot.Update(gameTime);
        }
        public void Draw(GameTime gameTime){
            // Logger.i("GM", "Game manager drawing content");
            spriteBatch.Begin();
            gameRoot.Draw(spriteBatch, Vector2.Zero);
            // spriteBatch.Draw(assetManager.pony_basic, new Vector2(20,20), Color.White);
            spriteBatch.End();
        }
    }
}