using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ponyform.Game;
using MonoGame.Extended.Input;

namespace Ponyform.UI
{
    public class DraggableIcon : Image
    {
        #region Fields

        private MouseStateExtended _mouseStateExtended;

        private Point _currentMouse;

        private Point _previousMouse;

        private bool _holding = false;

        #endregion

        #region Properties

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

        public DraggableIcon(Texture2D texture) : base(texture)
        {
            DefaultColor = Color.White;
            HoldingColor = Color.White;
        }

        public override void Update(GameTime gameTime)
        {
            _mouseStateExtended = MouseExtended.GetState();
            _currentMouse = _mouseStateExtended.Position;
            Rectangle mouseRectangle = new Rectangle(_mouseStateExtended.X, _mouseStateExtended.Y, 1, 1);

            if (mouseRectangle.Intersects(Rectangle) && _mouseStateExtended.WasButtonJustDown(MouseButton.Left))
            {
                _holding = true;
            }
            if (_mouseStateExtended.WasButtonJustUp(MouseButton.Left)) _holding = false;

            if (_holding)
            {
                SetPosition(pos + (_currentMouse - _previousMouse).ToVector2());
                _color = HoldingColor;
            } else
            {
                _color = DefaultColor;
            }

            _previousMouse = _currentMouse;
            base.Update(gameTime);
        }
    }
}
