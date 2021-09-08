using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using Ponyform.Event;
using Ponyform.UI;
using Ponyform.Utilities;

namespace Ponyform.Game.View {
    public class FoodBar : MoveableIcon
    {
        private AssetManager _am;
        private EventManager _em;

        //private Image bg;
        private DraggableIcon apple, blueberry, milk, grass;

        private int _horizontalAmount = 0;
        private int _verticalAmount = 0;

        private bool _preReached = false;
        private bool _visGoal = false;

        private Vector2 _enabledPos;
        private Vector2 _disabledPos;
        
        public FoodBar(Texture2D texture) : base(texture){
            _am = DI.Get<AssetManager>();
            _em = DI.Get<EventManager>();
            createView();
            arrangeView();
            _em.RegisterListener(GameEvent.ActivitySet, onActivitySet);

            //bg = new Image(_am.button_bottom_bg);

            Pony pony = DI.Get<Pony>();
            apple.RegisterCollider(pony.mouthBox,  
                () => _em.SendEvent(GameEvent.StartedEating, new EatingInfo { foodItem = Food.Apple }), 
                () => _em.SendEvent(GameEvent.StoppedEating));
            blueberry.RegisterCollider(pony.mouthBox,
                () => _em.SendEvent(GameEvent.StartedEating, new EatingInfo { foodItem = Food.Blueberry }),
                () => _em.SendEvent(GameEvent.StoppedEating));
            milk.RegisterCollider(pony.mouthBox,
                () => _em.SendEvent(GameEvent.StartedEating, new EatingInfo { foodItem = Food.Milk }),
                () => _em.SendEvent(GameEvent.StoppedEating));
            grass.RegisterCollider(pony.mouthBox,
                () => _em.SendEvent(GameEvent.StartedEating, new EatingInfo { foodItem = Food.Grass }),
                () => _em.SendEvent(GameEvent.StoppedEating));
        }

        private void createView() {
            apple = new DraggableIcon(_am.food_apple);
            blueberry = new DraggableIcon(_am.food_bb);
            milk = new DraggableIcon(_am.food_milk);
            grass = new DraggableIcon(_am.food_grass);
            
            AddAll(apple, blueberry, milk, grass);

            _horizontalAmount += 4;
            _verticalAmount += 1;
        }

        private void arrangeView() {
            float xPos = 0, yPos = 0;

            float iconWidth = size.X / (_horizontalAmount + 1);

            float iconHeight = size.Y * 0.6f / (_verticalAmount + 1);

            xPos += iconWidth;
            yPos += iconHeight;

            apple.SetPosition(xPos, yPos, Alignment.CENTER);
            xPos += iconWidth;
            blueberry.SetPosition(xPos, yPos, Alignment.CENTER);
            xPos += iconWidth;
            milk.SetPosition(xPos, yPos, Alignment.CENTER);
            xPos += iconWidth;
            grass.SetPosition(xPos, yPos, Alignment.CENTER);
            
            SetSize(new Vector2(size.X, size.Y));
            SetVisibility(false);
        }

        private void onActivitySet(object data){
            if (!Utils.TryConvertVal(data, out ActivitySelectInfo info)){
                return;
            }
            Logger.i("FoodBar", $"Activity Set = {info.type}");

            _preReached = false;

            if (_visGoal != (info.type == ActivityType.FEED))
            {
                _visGoal = (info.type == ActivityType.FEED);
                if (_visGoal)
                {
                    SetVisibility(_visGoal);
                    MoveTo(_enabledPos);
                }
                else MoveTo(_disabledPos);
            }
            
        }

        public override void Update(GameTime gameTime)
        {
            if (_preReached == false && _reached == true)
            {
                _preReached = true;
                if (!_visGoal)
                {
                    Logger.d("foodbar", $"set{_visGoal}");
                    SetVisibility(_visGoal);
                }
            }

            base.Update(gameTime);
        }

        public void SetIfEnabledPossition(Vector2 pos1, Vector2 pos2)
        {
            _enabledPos = pos1;
            _disabledPos = pos2;
        }
    }
}