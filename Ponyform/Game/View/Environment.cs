using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ponyform.UI;

namespace Ponyform.Game.View {
    public class Environment: GameObject {
        Image background;
        GameObject desk;
        private AssetManager am;
        public Environment(){
            am = DI.Get<AssetManager>();
            background = new Image(am.background);

            Add(background);
        }

        public override void Draw(SpriteBatch batch, Vector2 origin){
            // if (pos.X > 0 && pos.Y > 0){
                base.Draw(batch, origin);
            // }
        }
    }
}