using Microsoft.Xna.Framework;
using MonoGame.Extended;
using Ponyform.Event;
using Ponyform.UI;
using Ponyform.Utilities;

namespace Ponyform.Game.View {
    public class FoodBar: GameObject {
        private AssetManager _am;
        private EventManager _em;

        private Image bg;
        private DraggableIcon apple, blueberry, milk, grass;

        private int _horizontalAmount = 0;
        private int _verticalAmount = 0;
        
        public FoodBar(){
            _am = DI.Get<AssetManager>();
            _em = DI.Get<EventManager>();
            createView();
            arrangeView();
            _em.RegisterListener(GameEvent.ActivitySet, onActivitySet);
        }

        private void createView() {
            bg = new Image(_am.button_bottom_bg);
            apple = new DraggableIcon(_am.food_apple);
            blueberry = new DraggableIcon(_am.food_bb);
            milk = new DraggableIcon(_am.food_milk);
            grass = new DraggableIcon(_am.food_grass);
            
            AddAll( bg, apple, blueberry, milk, grass);

            _horizontalAmount += 4;
            _verticalAmount += 1;
        }

        private void arrangeView() {
            float xPos = 0, yPos = 0;

            float iconWidth = bg.size.X / (_horizontalAmount + 1);

            float iconHeight = bg.size.Y * 0.6f / (_verticalAmount + 1);

            xPos += iconWidth;
            yPos += iconHeight;

            apple.SetPosition(xPos, yPos, Alignment.CENTER);
            xPos += iconWidth;
            blueberry.SetPosition(xPos, yPos, Alignment.CENTER);
            xPos += iconWidth;
            milk.SetPosition(xPos, yPos, Alignment.CENTER);
            xPos += iconWidth;
            grass.SetPosition(xPos, yPos, Alignment.CENTER);
            
            SetSize(new Vector2(bg.size.X, bg.size.Y));
            SetVisibility(false);
        }

        private void onActivitySet(object data){
            if (!Utils.TryConvertVal(data, out ActivitySelectInfo info)){
                return;
            }
            Logger.i("FoodBar", $"Activity Set = {info.type}");
            SetVisibility(info.type == ActivityType.FEED);
        }
    }
}