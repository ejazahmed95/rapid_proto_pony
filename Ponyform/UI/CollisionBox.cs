using Microsoft.Xna.Framework;

namespace Ponyform.UI {
    public class CollisionBox : GameObject {
        private Rectangle MyRect => new Rectangle((int)globalPosition.X, (int)globalPosition.Y, (int)size.X, (int)size.Y);

        public CollisionBox(Vector2 size){
            SetSize(size);
        }
        
        public bool Intersects(Rectangle rect){
            return MyRect.Intersects(rect);
        }

        public bool Intersects(Vector2 globalPos){
            return MyRect.Contains(globalPos);
        }
    }
}