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
        public Texture2D button_feed, button_groom;
        public Texture2D food_apple, food_bb, food_grass, food_milk;
        public Texture2D button_side_bg, button_bottom_bg;
        public Texture2D star;

        // Placeholder assets
        public Texture2D ball;
        
        public AssetManager(ContentManager content){
            this.content = content;
        }
           
        public void LoadAssets(){
            // Environment
            background = content.Load<Texture2D>("Background/Background");
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

            background = content.Load<Texture2D>("Background/Background");
            
            // Pony
            pony_mid = content.Load<Texture2D>("Pony/Pony_Mid");
            pony_eye_1 = content.Load<Texture2D>("Pony/Eye1");
            pony_eye_2 = content.Load<Texture2D>("Pony/Eye2");
            pony_eye_3 = content.Load<Texture2D>("Pony/Eye3");

            // UI
            button_feed = content.Load<Texture2D>("UI/UI_Feed");
            button_groom = content.Load<Texture2D>("UI/UI_Groom");
            food_apple = content.Load<Texture2D>("UI/UI_Food_Apple");
            food_bb = content.Load<Texture2D>("UI/UI_Food_Blueberry");
            food_grass = content.Load<Texture2D>("UI/UI_Food_Grass");
            food_milk = content.Load<Texture2D>("UI/UI_Food_Milk");
            button_side_bg = content.Load<Texture2D>("UI/UI_side");
            button_bottom_bg = content.Load<Texture2D>("UI/UI_FoodBar");
            
            ball = content.Load<Texture2D>("Sprites/ball");
            star = content.Load <Texture2D>("UI/UI_star");
        }
    }
}