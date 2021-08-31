using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using Ponyform.Utilities;

namespace Ponyform.UI {
    public class GameObject {
        public Vector2 pos { get; private set; }
        public Vector2 size { get; private set; }
        
        /**
         * Write implementation for z index if required
         */
        public int zIndex = 1;

        public Vector2 globalPosition { get; private set; }
        
        private readonly List<GameObject> _children;
        public GameObject _parent { get; private set; }

        private bool enabled = true;

        public GameObject(){
            _children = new List<GameObject>();
            pos = new Vector2();
            size = new Vector2();
        }
        
        #region Hierarchy
        public void Add(GameObject obj){
            if (!_children.Contains(obj)){
                _children.Add(obj);
                obj.SetParent(this);
            };
        }

        public void AddAll(params GameObject[] objs){
            foreach (var gameObject in objs){
                Add(gameObject);
            }
        }

        public void Remove(GameObject obj){
            _children.Remove(obj);
        }

        private void SetParent(GameObject parent){
            this._parent?.Remove(this);
            this._parent = parent;
        }
        #endregion

        #region Gameloop

        public virtual void Update(GameTime gameTime){
            foreach (var gameObject in _children){
                gameObject.Update(gameTime);
            }
        }
        
        public virtual void Draw(SpriteBatch batch, Vector2 origin){
            // Logger.t("GO Draw", $"Game object drawing: {GetType()}");
            globalPosition = origin + pos;
            foreach (var go in _children){
                if(!go.Enabled()) continue;
                go.Draw(batch, origin + pos);
            }
        }

        #endregion

        #region Positioning

        public void SetPosition(Vector2 newPos){
            pos = new Vector2(newPos.X, newPos.Y);
        }
        
        public void SetPosition(float x, float y){
            pos = new Vector2(x, y);
        }
        
        public void SetPosition(float x, float y, Alignment alignment){
            SetPosition(new Vector2(x, y), alignment);
        }
        
        public void SetPosition(Vector2 newPos, Alignment alignment){
            var x = newPos.X;
            var y = newPos.Y;
            switch (alignment){
                case Alignment.TOP_LEFT:
                case Alignment.LEFT:
                case Alignment.BOTTOM_LEFT:
                    break;
                case Alignment.CENTER:
                case Alignment.TOP:
                case Alignment.BOTTOM:
                    x -= size.X / 2;
                    break;
                case Alignment.TOP_RIGHT:
                case Alignment.RIGHT:
                case Alignment.BOTTOM_RIGHT:
                    x -= size.X;
                    break;
            }
            switch (alignment){
                case Alignment.TOP_LEFT:
                case Alignment.TOP:
                case Alignment.TOP_RIGHT:
                    break;
                case Alignment.LEFT:
                case Alignment.CENTER:
                case Alignment.RIGHT:
                    y -= size.Y/2;
                    break;
                case Alignment.BOTTOM_LEFT:
                case Alignment.BOTTOM:
                case Alignment.BOTTOM_RIGHT:
                    y -= size.Y;
                    break;
            }
            pos = new Vector2(x, y);
        }

        public void SetSize(Vector2 newSize){
            size = new Vector2(newSize.X, newSize.Y);
        }

        public void SetWidth(float width){
            size = new Vector2(width, size.Y);
        }
        public void SetHeight(float height){
            size = new Vector2(size.X, height);
        }

        public void SetVisibility(bool enabled){
            this.enabled = enabled;
        }

        bool Enabled(){
            return enabled;
        }
        
        #endregion
    }
    
    
    public class EmptyGameObject: GameObject {}
    
}