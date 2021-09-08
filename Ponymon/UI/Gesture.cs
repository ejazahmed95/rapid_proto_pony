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

        private Color _nextColor = new Color(255, 255, 255);
        private Color _waitColor = new Color(0, 0, 0);

        #endregion

        #region Properties

        public List<Vector2> Positions { get; private set; }

        public int Amount { get
            {
                return _collisionBoxes.Count + 1;
            }
        }

        public bool Over { get; set; }

        #endregion

        #region Methods

        public Gesture(Texture2D texture, List<Vector2> positions, Vector2 size, DraggableIcon draggableIcon, Color nextColor, Color waitColor, Action started, Action finished, bool over)
        {
            ResetGesture(texture, positions, size, draggableIcon, nextColor, waitColor, started, finished, over);
        }

        public Gesture(GestureAttributes gestureAttributes, bool over)
        {
            ResetGesture(gestureAttributes, over);
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
                Over = true;       
            }
            else
            {
                Remove(_nextCollisionBox);
                _nextCollisionBox = _collisionBoxes.Dequeue();
                Add(_nextCollisionBox);
                Remove(_nextImage);
                _nextImage = _images.Dequeue();
                Add(_nextImage);
                _nextImage.SetColor(_nextColor);
                if (Amount == (Positions.Count - 1)) _started();
            }

        }

        public void ResetGesture(Texture2D texture, List<Vector2> positions, Vector2 size, DraggableIcon draggableIcon, Color nextColor, Color waitColor, Action started, Action finished, bool over)
        {
            Positions = positions;
            _draggableIcon = draggableIcon;
            _nextColor = nextColor;
            _waitColor = waitColor;

            if (_collisionBoxes != null)
            {
                foreach (CollisionBox collisionBox in _collisionBoxes) Remove(collisionBox);
            }

            if (_images != null)
            {
                foreach (Image image in _images) Remove(image);
            }
            if (_nextCollisionBox != null)
            {
                Remove(_nextCollisionBox);
                _nextCollisionBox = null;
            }
            if (_nextImage != null)
            {
                Remove(_nextImage);
                _nextImage = null;
            }
            _collisionBoxes = new Queue<CollisionBox>();
            _images = new Queue<Image>();

            foreach (Vector2 pos in Positions)
            {
                CollisionBox collisionBox = new CollisionBox(size * gameInfra.scale);
                collisionBox.SetPosition(pos * gameInfra.scale);
                _collisionBoxes.Enqueue(collisionBox);
                Add(collisionBox);

                Image image = new Image(texture);
                image.SetColor(_waitColor);
                image.SetPosition(pos * gameInfra.scale);
                _images.Enqueue(image);
                Add(image);
            }
            Over = over;

            RegisterAction(started, finished);

            Logger.i("Gesture", "Reseted");
        }

        public void ResetGesture(GestureAttributes gestureAttributes, bool over)
        {
            Positions = gestureAttributes.positions;
            _draggableIcon = gestureAttributes.draggableIcon;
            _nextColor = gestureAttributes.nextColor;
            _waitColor = gestureAttributes.waitColor;

            if (_collisionBoxes != null)
            {
                foreach (CollisionBox collisionBox in _collisionBoxes) Remove(collisionBox);
            }

            if (_images != null)
            {
                foreach (Image image in _images) Remove(image);
            }
            if (_nextCollisionBox != null)
            {
                Remove(_nextCollisionBox);
                _nextCollisionBox = null;
            }
            if (_nextImage != null)
            {
                Remove(_nextImage);
                _nextImage = null;
            }
            _collisionBoxes = new Queue<CollisionBox>();
            _images = new Queue<Image>();

            foreach (Vector2 pos in Positions)
            {
                CollisionBox collisionBox = new CollisionBox(size * gameInfra.scale);
                collisionBox.SetPosition(pos * gameInfra.scale);
                _collisionBoxes.Enqueue(collisionBox);
                Add(collisionBox);
                Image image = new Image(gestureAttributes.texture);
                image.SetColor(_waitColor);
                image.SetPosition(pos * gameInfra.scale);
                _images.Enqueue(image);
                Add(image);
            }
            Over = over;

            RegisterAction(gestureAttributes.started, gestureAttributes.finished);

            Logger.i("Gesture", "Reseted");
        }


        public override void Update(GameTime gameTime)
        {
            if (!Over)
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
