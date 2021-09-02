using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ponyform.Utilities;


namespace Ponyform.UI
{
    class Gesture : GameObject
    {
        #region Fields

        private Queue<CollisionBox> _collisionBoxes;
        private Queue<Image> _images;

        private CollisionBox _nextCollisionBox;
        private Image _nextImage;

        private DraggableIcon _draggableIcon;

        private Action _started;
        private Action _finished;

        private Color _nextColor = new Color(0, 0, 0);

        private bool _over = false;

        #endregion

        #region Properties

        public List<Vector2> Positions { get; private set; }
        public Vector2 Size { get; private set; }

        public int Amount { get
            {
                return _collisionBoxes.Count + 1;
            }
        }


        #endregion

        #region Methods

        public Gesture(Texture2D texture, List<Vector2> positions, Vector2 size, DraggableIcon draggableIcon, Color nextColor, Action started, Action finished)
        {
            ResetGesture(texture, positions, size, draggableIcon, nextColor, started, finished);
        }

        internal void RegisterAction(Action started, Action finished)
        {
            _started = started;
            _finished = finished;
        }


        private void nextStep()
        {
            Remove(_nextCollisionBox);
            Remove(_nextImage);

            if (Amount <= 1)
            {
                _nextCollisionBox = null;
                _nextImage = null;
                
                _finished();
                _over = true;       
            }
            else
            {
                _nextCollisionBox = _collisionBoxes.Dequeue();
                Add(_nextCollisionBox);
                _nextImage = _images.Dequeue();
                Add(_nextImage);
                _nextImage.SetColor(_nextColor);
                if (Amount == (Positions.Count - 1)) _started();
            }

        }

        public void ResetGesture(Texture2D texture, List<Vector2> positions, Vector2 size, DraggableIcon draggableIcon, Color nextColor, Action started, Action finished)
        {
            Positions = positions;
            Size = size;
            _draggableIcon = draggableIcon;
            _nextColor = nextColor;

            _collisionBoxes = new Queue<CollisionBox>();
            _images = new Queue<Image>();

            foreach (Vector2 pos in Positions)
            {
                CollisionBox collisionBox = new CollisionBox(size);
                collisionBox.SetPosition(pos);
                _collisionBoxes.Enqueue(collisionBox);
                Add(collisionBox);

                Image image = new Image(texture);
                image.SetPosition(pos);
                _images.Enqueue(image);
                Add(image);
            }
            _over = false;

            RegisterAction(started, finished);

            Logger.i("Gesture", "Reseted");
        }


        public override void Update(GameTime gameTime)
        {
            if (!_over)
            {
                if (_nextCollisionBox == null) nextStep();

                if (_nextCollisionBox.Intersects(_draggableIcon.Rectangle))
                {
                    Logger.i("Gesture", "hit");
                    nextStep();
                }
            }

            base.Update(gameTime);
        }

        #endregion
    }
}
