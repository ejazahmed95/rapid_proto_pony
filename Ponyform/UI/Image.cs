using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ponyform.Game;

namespace Ponyform.UI {
    public class Image: GameObject {
        protected Texture2D _tex;
        protected Color _color = Color.White;
        protected float scale;
        
        protected Rectangle Rectangle => new Rectangle((int)globalPosition.X, (int)globalPosition.Y, (int)size.X, (int)size.Y);
        
        public Image(Texture2D texture){
            scale = DI.Get<GameInfra>().scale;
            this._tex = texture;
            SetWidth(texture.Width*scale);
            SetHeight(texture.Height*scale);
        }

        public override void Draw(SpriteBatch batch, Vector2 origin){
            batch.Draw(_tex, pos + origin, null, _color, 0, new Vector2(), scale, 0, 0);
            base.Draw(batch, origin);
        }

    }
}