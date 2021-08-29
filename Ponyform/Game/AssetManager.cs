using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Ponyform.Game
{
    public class AssetManager {
        private ContentManager content;
        // Background
        public Texture2D background, calendar, carpet, desk, floor, flower1, flower2, light, posters, wall, window;
        
        // Pony
        public Texture2D pony_mid, pony_eye_1, pony_eye_2, pony_eye_3;
        
        // UI
        

        public AssetManager(ContentManager content){
            this.content = content;
        }
           
        public void LoadAssets(){
            // Environment
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
            
            // Pony
            pony_mid = content.Load<Texture2D>("Pony/Pony_Mid");
            pony_eye_1 = content.Load<Texture2D>("Pony/Eye1");
            pony_eye_2 = content.Load<Texture2D>("Pony/Eye2");
            pony_eye_3 = content.Load<Texture2D>("Pony/Eye3");

            // UI
        }
    }
}