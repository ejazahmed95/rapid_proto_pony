using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input.InputListeners;
using Ponyform.Event;
using Ponyform.Game;
using Ponyform.Utilities;

namespace Ponyform
{
    public class PonyGame : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private GameManager _gameManager;

        public PonyGame()
        {
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
            // Setup
            DI.Register(new GameInfra(this));
            DI.Register<AssetManager>(new AssetManager(Content));
            DI.Register(new SoundManager(Content));
            DI.Register(new EventManager());
            _gameManager = new GameManager(); 
            DI.Register(_gameManager);
        }

        /*
         * This is called after LoadContent
         */
        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent(){

            Logger.i("Ponymon", "Loading content"); 
            
            DI.Get<GameInfra>().Load();
            SetupInput();
            DI.Get<AssetManager>().LoadAssets();
            DI.Get<SoundManager>().LoadAssets();
            DI.Get<GameManager>().OnGameInit();
            
            Logger.i("Ponymon", "Content loading finished");
        }

        private void SetupInput(){
            var _keyboardListener = new KeyboardListener();
            var _mouseListener = new MouseListener();
            var _touchListener = new TouchListener();
            
            Components.Add(new InputListenerComponent(this, _keyboardListener, _mouseListener, _touchListener));
            DI.Register(_keyboardListener);
            DI.Register(_mouseListener);
            DI.Register(_touchListener);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            // TODO: Add your update logic here
            _gameManager.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // Logger.i("PonyGame", "draw method called");
            
            _gameManager.Draw(gameTime);
            
            // TODO: Add your drawing code here
            foreach (var component in Components){
                if (component is DrawableGameComponent gameComponent){
                    gameComponent.Draw(gameTime);
                }
            }

            base.Draw(gameTime);
        }
    }
}