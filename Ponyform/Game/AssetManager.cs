using System.Net.Mime;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Ponyform.Game
{
    public class AssetManager {
        private ContentManager content;
        // Assets List
        public Texture2D pony_basic;

        public AssetManager(ContentManager content){
            this.content = content;
        }
           
        public void LoadAssets(){
            pony_basic = content.Load<Texture2D>("Sprites/ball");
        }
    }
}