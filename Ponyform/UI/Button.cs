using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Input;
using System;
using Ponyform.Event;
using Ponyform.UI;
using Ponyform.Utilities;
using Ponyform.Game;

namespace Ponyform.UI
{
    class Button : Image
    {
        #region Fields

        private MouseStateExtended _mouseStateExtended;

        private readonly EventManager _em;

        private GameEvent _gameEvent;

        private Action<object> _listener;

        private object _data;

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

        public Button(Texture2D texture, GameEvent gameEvent, Action<object> listener, object data) : base(texture)
        {
            DefaultColor = Color.White;
            HoldingColor = Color.White;

            _em = DI.Get<EventManager>();
            _gameEvent = gameEvent;
            _listener = listener;
            _data = data;

            _em.RegisterListener(gameEvent, listener);

        }

        public override void Update(GameTime gameTime)
        {
            _mouseStateExtended = MouseExtended.GetState();

            Rectangle mouseRectangle = new Rectangle(_mouseStateExtended.X, _mouseStateExtended.Y, 1, 1);
            if (mouseRectangle.Intersects(Rectangle) && _mouseStateExtended.WasButtonJustDown(MouseButton.Left))
            {
                _color = HoldingColor;

                _em.SendEvent(_gameEvent, _data);

            }
            if (_mouseStateExtended.WasButtonJustUp(MouseButton.Left))
            {
                _color = DefaultColor;
            }

            base.Update(gameTime);
        }
    }
}
