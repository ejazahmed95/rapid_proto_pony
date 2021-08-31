using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Input;
using System;
using System.Diagnostics;
using Ponyform.Event;
using Ponyform.Game;

namespace Ponyform.UI
{
    class Button : Image
    {
        #region Fields

        private MouseStateExtended _mouseStateExtended;

        private readonly EventManager _em;

        private GameEvent _gameEvent;

        private Action _onClickAction;
        private Action<object> _listener;

        private object _data;

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

        public Button(Texture2D texture, Action onClick) : base(texture)
        {
            DefaultColor = Color.White;
            HoldingColor = Color.White;

            _em = DI.Get<EventManager>();
            _onClickAction = onClick;
            // _gameEvent = gameEvent;
            // _listener = listener;
            // _data = data;

        }

        public override void Update(GameTime gameTime)
        {
            _mouseStateExtended = MouseExtended.GetState();

            Rectangle mouseRectangle = new Rectangle(_mouseStateExtended.X, _mouseStateExtended.Y, 1, 1);
            if (mouseRectangle.Intersects(Rectangle) && _mouseStateExtended.IsButtonDown(MouseButton.Left))
            {
                if (!_holding)
                {
                    _holding = true;
                    _color = HoldingColor;
                }
                
            }
            if (_mouseStateExtended.IsButtonUp(MouseButton.Left))
            {
                if (_holding)
                {
                    _holding = false;
                    _color = DefaultColor;
                    _onClickAction();
                }
            }
            base.Update(gameTime);
        }
    }
}
