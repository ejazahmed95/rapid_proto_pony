using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Input;
using MonoGame.Extended.Input.InputListeners;
using Ponyform.Game;

namespace Ponyform.UI
{
    public class DraggableIcon : Image
    {
        #region Fields

        private MouseStateExtended _mouseStateExtended;

        private Point _currentMouse;

        private Point _previousMouse;

        private bool _holding = false;

        private Vector2 originalPos;
        private MouseListener _mouseListener;

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

            _mouseListener = DI.Get<MouseListener>();
            _mouseListener.MouseDragStart += OnMouseDragStart;
            _mouseListener.MouseDragEnd += OnMouseDragEnd;
        }

        private void SetOriginalPosition(Vector2 newPos){
            originalPos = new Vector2(newPos.X, newPos.Y);
        }
        
        private void OnMouseDragStart(object? sender, MouseEventArgs mouseEventArgs){
            if (Intersects()){
                _holding = true;
                originalPos = new Vector2(pos.X, pos.Y);
                SetPosition(_mouseStateExtended.X - _parent.globalPosition.X, _mouseStateExtended.Y - _parent.globalPosition.Y);
            }
        }
        
        private void OnMouseDragEnd(object? sender, MouseEventArgs mouseEventArgs){
            if (!_holding) return;
            SetPosition(new Vector2(originalPos.X, originalPos.Y));
            _holding = false;
        }

        private bool Intersects(){
            _mouseStateExtended = MouseExtended.GetState();
            Rectangle mouseRectangle = new Rectangle(_mouseStateExtended.X, _mouseStateExtended.Y, 1, 1);
            return mouseRectangle.Intersects(Rectangle);
        }
        
        public override void Update(GameTime gameTime){
            if (!_holding) return;
            _mouseStateExtended = MouseExtended.GetState();
            _currentMouse = _mouseStateExtended.Position;
            SetPosition(_mouseStateExtended.X - _parent.globalPosition.X, _mouseStateExtended.Y - _parent.globalPosition.Y);
            // Rectangle mouseRectangle = new Rectangle(_mouseStateExtended.X, _mouseStateExtended.Y, 1, 1);
            //
            // if (mouseRectangle.Intersects(Rectangle) && _mouseStateExtended.IsButtonDown(MouseButton.Left))
            // {
            //     if (!_holding) _holding = true;
            //     _color = HoldingColor;
            // }
            // if (_mouseStateExtended.IsButtonUp(MouseButton.Left))
            // {
            //     if (_holding) _holding = false;
            //     _color = DefaultColor;
            //
            //     Debug.WriteLine(pos);
            // }
            //
            // if (_holding)
            // {
            //     SetPosition(pos + (_currentMouse - _previousMouse).ToVector2());
            // }
            //
            // _previousMouse = _currentMouse;
            base.Update(gameTime);
        }
    }
}
