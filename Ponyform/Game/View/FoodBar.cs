using Microsoft.Xna.Framework;
using MonoGame.Extended;
using Ponyform.UI;

namespace Ponyform.Game.View {
    public class FoodBar: GameObject {
        private AssetManager _am;

        private Image bg;
        private DraggableIcon apple, blueberry, milk, grass;
        
        public FoodBar(){
            _am = DI.Get<AssetManager>();
            createView();
            arrangeView();
        }

        private void createView() {
            bg = new Image(_am.button_bottom_bg);
            apple = new DraggableIcon(_am.food_apple);
            blueberry = new DraggableIcon(_am.food_bb);
            milk = new DraggableIcon(_am.food_milk);
            grass = new DraggableIcon(_am.food_grass);
            
            AddAll( bg, apple, blueberry, milk, grass);
        }

        private void arrangeView() {
            float xPos = 0, yPos = 0, iconWidth = 100f;
            apple.SetPosition(xPos, yPos);
            xPos += iconWidth;
            blueberry.SetPosition(xPos, yPos);
            xPos += iconWidth;
            milk.SetPosition(xPos, yPos);
            xPos += iconWidth;
            grass.SetPosition(xPos, yPos);
            
            SetSize(new Vector2(bg.size.X, bg.size.Y));
        }
    }
}