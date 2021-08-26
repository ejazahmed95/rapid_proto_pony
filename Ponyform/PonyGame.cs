using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Ponyform.Game;

namespace Ponyform
{
    public class PonyGame : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public PonyGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
            
            // Setup
            DI.Register(new AssetManager(Content));
            DI.Register(new SoundManager());
            DI.Register(new GameInfra());
            DI.Register(new GameManager(this));
        }

        protected override void LoadContent()
        {
            Console.WriteLine("calling get");
            // DI.Get<GameInfra>().Load(GraphicsDevice);
            DI.Get<AssetManager>();
            // DI.Get<SoundManager>().LoadAssets();
            // DI.Get<GameManager>().OnGameInit();
        }

        protected override void Update(GameTime gameTime)
        {
            Console.Error.Write("calling update");
            Console.Error.Flush();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}