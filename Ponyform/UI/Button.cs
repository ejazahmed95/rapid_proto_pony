using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Input;
using System;

namespace Ponyform.UI
{
    class Button : Image
    {
        #region Fields

        private MouseStateExtended _mouseStateExtended;

        private bool _holding = false;

        #endregion

        #region Properties

        public event EventHandler Click;

        public Color DefaultColor { get; set; }

        public Color HoldingColor { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)globalPosition.X, (int)globalPosition.Y, _tex.Width, _tex.Height);
            }
        }
        #endregion

        public Button(Texture2D texture) : base(texture)
        {
            DefaultColor = Color.White;
            HoldingColor = Color.White;
        }

        public override void Update(GameTime gameTime)
        {
            _mouseStateExtended = MouseExtended.GetState();

            Rectangle mouseRectangle = new Rectangle(_mouseStateExtended.X, _mouseStateExtended.Y, 1, 1);
            if (mouseRectangle.Intersects(Rectangle) && _mouseStateExtended.WasButtonJustDown(MouseButton.Left))
            {
                _holding = true;
                Click?.Invoke(this, new EventArgs());
            }
            if (_mouseStateExtended.WasButtonJustUp(MouseButton.Left)) _holding = false;

            base.Update(gameTime);
        }
    }
}
