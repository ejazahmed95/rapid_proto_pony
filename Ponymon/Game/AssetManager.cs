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
        public Texture2D pony_mouth_1, pony_mouth_2, pony_mouth_3;
        public Texture2D pony_hair0_front, pony_hair1_front, pony_hair2_front, pony_hair3_front, pony_hair4_front, pony_hair5_front;
        public Texture2D pony_tail0, pony_tail1, pony_tail2, pony_tail3, pony_tail4, pony_tail5;
        
        // Pony Hair
        public Texture2D pony_hair0_back, pony_hair0_back_1, pony_hair0_back_2, pony_hair0_back_3, pony_hair0_back_4, pony_hair0_back_5, pony_hair0_back_6, pony_hair0_back_7;
        public Texture2D pony_hair1_back, pony_hair1_back_1, pony_hair1_back_2, pony_hair1_back_3, pony_hair1_back_4, pony_hair1_back_5, pony_hair1_back_6, pony_hair1_back_7;
        public Texture2D pony_hair2_back, pony_hair2_back_1, pony_hair2_back_2, pony_hair2_back_3, pony_hair2_back_4, pony_hair2_back_5, pony_hair2_back_6, pony_hair2_back_7;
        public Texture2D pony_hair3_back, pony_hair3_back_1, pony_hair3_back_2, pony_hair3_back_3, pony_hair3_back_4, pony_hair3_back_5, pony_hair3_back_6, pony_hair3_back_7;
        public Texture2D pony_hair4_back, pony_hair4_back_1, pony_hair4_back_2, pony_hair4_back_3, pony_hair4_back_4, pony_hair4_back_5, pony_hair4_back_6, pony_hair4_back_7;
        public Texture2D pony_hair5_back, pony_hair5_back_1, pony_hair5_back_2, pony_hair5_back_3, pony_hair5_back_4, pony_hair5_back_5, pony_hair5_back_6, pony_hair5_back_7;
        
        // UI
        public Texture2D button_feed, button_groom, arrow_bottom;
        public Texture2D food_apple, food_bb, food_grass, food_milk;
        public Texture2D button_side_bg, button_bottom_bg, groom_bottom_bg;
        public Texture2D play_button, quit_button;
        public Texture2D star;
        
        // Dialogues
        public Texture2D dialogue_eat_apple, dialogue_eat_bb, dialogue_eat_milk, dialogue_eat_grass;

        // Placeholder assets
        public Texture2D ball;
        public Texture2D groom_brush, groom_comb, groom_curling_iron;
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
            pony_mouth_1 = content.Load<Texture2D>("Pony/Chewing1");
            pony_mouth_2 = content.Load<Texture2D>("Pony/Chewing2");
            pony_mouth_3 = content.Load<Texture2D>("Pony/Chewing3");

            #region Hair Styles
            pony_hair0_back = content.Load<Texture2D>("Pony/Hair/0/0");
            pony_hair0_back_1 = content.Load<Texture2D>("Pony/Hair/0/1");
            pony_hair0_back_2 = content.Load<Texture2D>("Pony/Hair/0/2");
            pony_hair0_back_3 = content.Load<Texture2D>("Pony/Hair/0/3");
            pony_hair0_back_4 = content.Load<Texture2D>("Pony/Hair/0/4");
            pony_hair0_back_5 = content.Load<Texture2D>("Pony/Hair/0/5");
            pony_hair0_back_6 = content.Load<Texture2D>("Pony/Hair/0/6");
            pony_hair0_back_7 = content.Load<Texture2D>("Pony/Hair/0/7");
            
            pony_hair1_back = content.Load<Texture2D>("Pony/Hair/1/0");
            pony_hair1_back_1 = content.Load<Texture2D>("Pony/Hair/1/1");
            pony_hair1_back_2 = content.Load<Texture2D>("Pony/Hair/1/2");
            pony_hair1_back_3 = content.Load<Texture2D>("Pony/Hair/1/3");
            pony_hair1_back_4 = content.Load<Texture2D>("Pony/Hair/1/4");
            pony_hair1_back_5 = content.Load<Texture2D>("Pony/Hair/1/5");
            pony_hair1_back_6 = content.Load<Texture2D>("Pony/Hair/1/6");
            pony_hair1_back_7 = content.Load<Texture2D>("Pony/Hair/1/7");
            
            pony_hair2_back = content.Load<Texture2D>("Pony/Hair/2/0");
            pony_hair2_back_1 = content.Load<Texture2D>("Pony/Hair/2/1");
            pony_hair2_back_2 = content.Load<Texture2D>("Pony/Hair/2/2");
            pony_hair2_back_3 = content.Load<Texture2D>("Pony/Hair/2/3");
            pony_hair2_back_4 = content.Load<Texture2D>("Pony/Hair/2/4");
            pony_hair2_back_5 = content.Load<Texture2D>("Pony/Hair/2/5");
            pony_hair2_back_6 = content.Load<Texture2D>("Pony/Hair/2/6");
            pony_hair2_back_7 = content.Load<Texture2D>("Pony/Hair/2/7");
            
            pony_hair3_back = content.Load<Texture2D>("Pony/Hair/3/0");
            pony_hair3_back_1 = content.Load<Texture2D>("Pony/Hair/3/1");
            pony_hair3_back_2 = content.Load<Texture2D>("Pony/Hair/3/2");
            pony_hair3_back_3 = content.Load<Texture2D>("Pony/Hair/3/3");
            pony_hair3_back_4 = content.Load<Texture2D>("Pony/Hair/3/4");
            pony_hair3_back_5 = content.Load<Texture2D>("Pony/Hair/3/5");
            pony_hair3_back_6 = content.Load<Texture2D>("Pony/Hair/3/6");
            pony_hair3_back_7 = content.Load<Texture2D>("Pony/Hair/3/7");
            
            pony_hair4_back = content.Load<Texture2D>("Pony/Hair/4/0");
            pony_hair4_back_1 = content.Load<Texture2D>("Pony/Hair/4/1");
            pony_hair4_back_2 = content.Load<Texture2D>("Pony/Hair/4/2");
            pony_hair4_back_3 = content.Load<Texture2D>("Pony/Hair/4/3");
            pony_hair4_back_4 = content.Load<Texture2D>("Pony/Hair/4/4");
            pony_hair4_back_5 = content.Load<Texture2D>("Pony/Hair/4/5");
            pony_hair4_back_6 = content.Load<Texture2D>("Pony/Hair/4/6");
            pony_hair4_back_7 = content.Load<Texture2D>("Pony/Hair/4/7");
            
            pony_hair5_back = content.Load<Texture2D>("Pony/Hair/5/0");
            pony_hair5_back_1 = content.Load<Texture2D>("Pony/Hair/5/1");
            pony_hair5_back_2 = content.Load<Texture2D>("Pony/Hair/5/2");
            pony_hair5_back_3 = content.Load<Texture2D>("Pony/Hair/5/3");
            pony_hair5_back_4 = content.Load<Texture2D>("Pony/Hair/5/4");
            pony_hair5_back_5 = content.Load<Texture2D>("Pony/Hair/5/5");
            pony_hair5_back_6 = content.Load<Texture2D>("Pony/Hair/5/6");
            pony_hair5_back_7 = content.Load<Texture2D>("Pony/Hair/5/7");
            
            
            pony_hair0_front = content.Load<Texture2D>("Pony/Hair/Hair_Default_Front");
            pony_hair1_front = content.Load<Texture2D>("Pony/Hair/Hair1_Front");
            pony_hair2_front = content.Load<Texture2D>("Pony/Hair/Hair2_Front");
            pony_hair3_front = content.Load<Texture2D>("Pony/Hair/Hair3_Front");
            pony_hair4_front = content.Load<Texture2D>("Pony/Hair/Hair4_Front");
            pony_hair5_front = content.Load<Texture2D>("Pony/Hair/Hair5_Front");
            #endregion
            
            // Tail
            pony_tail0 = content.Load<Texture2D>("Pony/Tail/Tail_Default");
            pony_tail1 = content.Load<Texture2D>("Pony/Tail/Tail1");
            pony_tail2 = content.Load<Texture2D>("Pony/Tail/Tail2");
            pony_tail3 = content.Load<Texture2D>("Pony/Tail/Tail3");
            pony_tail4 = content.Load<Texture2D>("Pony/Tail/Tail4");
            pony_tail5 = content.Load<Texture2D>("Pony/Tail/Tail5");
            
            // UI
            button_feed = content.Load<Texture2D>("UI/UI_Feed");
            button_groom = content.Load<Texture2D>("UI/UI_Groom");
            food_apple = content.Load<Texture2D>("UI/UI_Food_Apple");
            food_bb = content.Load<Texture2D>("UI/UI_Food_Blueberry");
            food_grass = content.Load<Texture2D>("UI/UI_Food_Grass");
            food_milk = content.Load<Texture2D>("UI/UI_Food_Milk");
            groom_brush = content.Load<Texture2D>("UI/UI_Groom_Brush");
            groom_comb = content.Load<Texture2D>("UI/UI_Groom_Comb");
            groom_curling_iron = content.Load<Texture2D>("UI/UI_Groom_CurlingIron");
            button_side_bg = content.Load<Texture2D>("UI/UI_side");
            button_bottom_bg = content.Load<Texture2D>("UI/UI_FoodBar");
            groom_bottom_bg = content.Load<Texture2D>("UI/UI_GroomBar");
            arrow_bottom = content.Load<Texture2D>("UI/UI_Arrow");
            play_button = content.Load<Texture2D>("UI/UI_Play");
            quit_button = content.Load<Texture2D>("UI/UI_Quit");
            
            // Dialogues
            dialogue_eat_apple = content.Load<Texture2D>("UI/UI_DiaApple");
            dialogue_eat_bb = content.Load<Texture2D>("UI/UI_DiaBlueberry");
            dialogue_eat_milk = content.Load<Texture2D>("UI/UI_DiaMilk");
            dialogue_eat_grass = content.Load<Texture2D>("UI/UI_DiaGrass");
            
            ball = content.Load<Texture2D>("Sprites/ball");
            star = content.Load <Texture2D>("UI/UI_star");
        }
    }
}