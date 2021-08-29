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
        private GameObject _parent;

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
            Logger.t("GO Draw", $"Game object drawing: {GetType()}");
            foreach (var go in _children){
                go.Draw(batch, origin + pos);
            }
        }

        #endregion

        #region Positioning

        public void SetPosition(Vector2 newPos){
            pos = new Vector2(newPos.X, newPos.Y);
            // pos.SetX(newPos.X);
            // pos.SetY(newPos.Y);
        }

        public void SetSize(Vector2 newSize){
            size.SetX(newSize.X);
            size.SetY(newSize.Y);
        }

        public void SetWidth(float width){
            size.SetX(width);
        }
        public void SetHeight(float height){
            size.SetY(height);
        }

        #endregion
    }
    
    public class EmptyGameObject: GameObject {}
    
}