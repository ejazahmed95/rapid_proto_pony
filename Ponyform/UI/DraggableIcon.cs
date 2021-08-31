using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Input;
using System.Diagnostics;

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

        //set the color when it is not being held 
        public Color DefaultColor { get; set; }

        //set the color when it is being held 
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

            if (mouseRectangle.Intersects(Rectangle) && _mouseStateExtended.IsButtonDown(MouseButton.Left))
            {
                if (!_holding) _holding = true;
                _color = HoldingColor;
            }
            if (_mouseStateExtended.IsButtonUp(MouseButton.Left))
            {
                if (_holding) _holding = false;
                _color = DefaultColor;
            }

            if (_holding)
            {
                SetPosition(pos + (_currentMouse - _previousMouse).ToVector2());
            }

            _previousMouse = _currentMouse;
            base.Update(gameTime);
        }
    }
}
