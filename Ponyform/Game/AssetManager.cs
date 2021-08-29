using System.Net.Mime;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Content;

namespace Ponyform.Game
{
    public class AssetManager {
        private ContentManager content;
        // Background
        public Texture2D background, calendar, carpet, desk, floor, flower1, flower2, light, posters, wall, window;
        
        // Pony
        
        // 
        
        public AssetManager(ContentManager content){
            this.content = content;
        }
           
        public void LoadAssets(){
            // background = content.Load<Texture2D>("Background/Background");
            calendar = content.Load<Texture2D>("Background/Calender");
            carpet = content.Load<Texture2D>("Background/Carpet");
            desk = content.Load<Texture2D>("Background/Desk");
            floor = content.Load<Texture2D>("Background/Floor");
            flower1 = content.Load<Texture2D>("Background/Flower1");
            flower2 = content.Load<Texture2D>("Background/Flower2");
            light = content.Load<Texture2D>("Background/Light");
            posters = content.Load<Texture2D>("Background/Posters");
            wall = content.Load<Texture2D>("Background/Wall");
            window = content.Load<Texture2D>("Background/Window");
        }
    }
}