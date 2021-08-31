using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Input;
using MonoGame.Extended.Input.InputListeners;
using Ponyform.Game;
using System;
using Ponyform.Utilities;

namespace Ponyform.UI
{
    public class DraggableIcon : Image
    {
        #region Fields

        private MouseStateExtended _mouseStateExtended;

        private Point _currentMouse;

        private bool _holding = false;

        private Vector2 originalPos;
        private MouseListener _mouseListener;
        private CollisionBox _mouthBox;
        private Action _onEnterCb;
        private Action _onExitCb;

        #endregion

        #region Properties

        //set the color when it is not being held 
        public Color DefaultColor { get; set; }

        //set the color when it is being held 
        public Color HoldingColor { get; set; }

        /*
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)globalPosition.X, (int)globalPosition.Y, _tex.Width, _tex.Height);
            }
        }
        */

        public bool Interacting { get; set; }

        #endregion

        public DraggableIcon(Texture2D texture) : base(texture)
        {
            DefaultColor = Color.White;
            HoldingColor = Color.White;

            Interacting = false;

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

        internal void RegisterCollider(CollisionBox mouthBox, Action onEnterCb, Action onExitCb)
        {
            _mouthBox = mouthBox;
            _onEnterCb = onEnterCb;
            _onExitCb = onExitCb;
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
            if(_mouthBox != null) {
                if (_mouthBox.Intersects(Rectangle))
                {
                    if (!Interacting)
                    {
                        _onEnterCb();
                        Interacting = true;
                        //Logger.i("DraggableIcon", "Entered");
                    }
                }
                else
                {
                    if (Interacting)
                    {
                        _onExitCb();
                        Interacting = false;
                        //Logger.i("DraggableIcon", "Exitted");
                    }
                }
            }

            base.Update(gameTime);
        }
    }
}
