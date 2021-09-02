using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Input;
using System;
using System.ComponentModel;
using MonoGame.Extended.Input.InputListeners;
using Ponyform.Event;
using Ponyform.Game;
using Ponyform.Utilities;
using Ponyform.UI;

namespace Ponyform.Utilities
{
    class MouseStateDetecter : GameObject
    {
        private readonly MouseListener _mouseListener;
        private MouseStateExtended _mouseStateExtended;


        public MouseStateDetecter() 
        {
            _mouseStateExtended = MouseExtended.GetState();
            _mouseListener = DI.Get<MouseListener>();
            _mouseListener.MouseClicked += OnMouseClick;

            Logger.d("MouseStateDetecter", $"created");
        }

        private void OnMouseClick(object? sender, MouseEventArgs e)
        {
            _mouseStateExtended = MouseExtended.GetState();
            Vector2 mousePosition = new Vector2(_mouseStateExtended.X, _mouseStateExtended.Y);
            Logger.d("MouseStateDetecter", $"Position: {mousePosition - _parent.pos}");
        }

        public override void Update(GameTime gameTime)
        {
            //Vector2 mousePosition = new Vector2(_mouseStateExtended.X, _mouseStateExtended.Y);
            //Logger.d("MouseStateDetecter", $"Position: {mousePosition}");
        }
    }
}
