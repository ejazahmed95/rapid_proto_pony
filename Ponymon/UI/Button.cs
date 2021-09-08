using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Input;
using System;
using System.ComponentModel;
using MonoGame.Extended.Input.InputListeners;
using Ponyform.Event;
using Ponyform.Game;
using Ponyform.Utilities;

namespace Ponyform.UI
{
    class Button : Image
    {
        #region Fields

        private MouseStateExtended _mouseStateExtended;
        private readonly MouseListener _mouseListener;
        private Action _onClickAction;

        #endregion

        #region Properties
        public Color DefaultColor { get; set; }
        public Color HoldingColor { get; set; }
        private BtnState _state = BtnState.Idle;

        #endregion

        public Button(Texture2D texture, Action onClick) : base(texture)
        {
            DefaultColor = Color.White;
            HoldingColor = Color.White;

            _mouseListener = DI.Get<MouseListener>();
            _mouseListener.MouseClicked += OnMouseClick;
            _onClickAction = onClick;
            
        }

        private void OnMouseClick(object? sender, MouseEventArgs e){
            Logger.d("Button", "Mouse Clicked!!");
            _mouseStateExtended = MouseExtended.GetState();
            Rectangle mouseRectangle = new Rectangle(_mouseStateExtended.X, _mouseStateExtended.Y, 1, 1);
            if (mouseRectangle.Intersects(Rectangle)){
                _onClickAction();
                Logger.i("Button", "Button Area Clicked!!");
            } else {
                _state = BtnState.Idle;
                SetColorForState(_state);
            }
        }

        private void SetColorForState(BtnState btnState){
            switch (btnState){
                case BtnState.Idle:
                    _color = DefaultColor;
                    break;
                case BtnState.Disabled:
                    break;
                case BtnState.Held:
                    _color = HoldingColor;
                    break;
            }
        }
    }

    enum BtnState {
        Idle,
        Disabled,
        Held,
    }
}
