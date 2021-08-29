using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ponyform.Game;

namespace Ponyform.UI {
    public class Image: GameObject {
        private Texture2D _tex;
        private Color _color = Color.White;
        public Image(Texture2D texture){
            this._tex = texture;
        }

        public override void Draw(SpriteBatch batch, Vector2 origin){
            // if (origin.X > 0 && origin.Y > 0){
                batch.Draw(_tex, origin + pos, _color);
            // }
            base.Draw(batch, origin);
        }
    }
}