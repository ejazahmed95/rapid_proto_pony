using Ponyform.UI;

namespace Ponyform.Game.View {
    public class FoodBar: GameObject {
        private AssetManager _am;

        private Image bg;
        private DraggableIcon apple, blueberry, milk, grass;
        
        public FoodBar(){
            _am = DI.Get<AssetManager>();
            
        }
    }
}