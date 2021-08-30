using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ponyform.UI
{
    class MoveableIcon : Image
    {
        #region Fields 

        private bool _reached = true;

        private Vector2 _startPosition;

        private float _progress;

        private float _totalTime = 0.1f;

        #endregion

        #region Properties

        public Vector2 Destination { get; set; }

        //How long it takes
        public float Duration { get; set; }

        #endregion

        public MoveableIcon(Texture2D texture) : base(texture)
        {
            Destination = pos;
        }

        public override void Update(GameTime gameTime)
        {
            if (!_reached)
            {
                if (Vector2.Distance(pos, Destination) <= 0.1f)
                {
                    _reached = true;
                    _totalTime = 0f;
                }
                _totalTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                _progress = _totalTime / Duration;
                Vector2 position = new Vector2(MathHelper.SmoothStep(_startPosition.X, Destination.X, _progress), MathHelper.SmoothStep(_startPosition.Y, Destination.Y, _progress));
                SetPosition(position);
            }

            base.Update(gameTime);
        }

        //Set movement
        public void MoveTo(Vector2 desitination, float duration = 1f)
        {
            Destination = desitination;
            _startPosition = pos;
            _reached = false;
            Duration = duration;
        }
    }
}
