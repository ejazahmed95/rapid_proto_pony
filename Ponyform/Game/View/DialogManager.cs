using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Ponyform.Event;
using Ponyform.UI;

namespace Ponyform.Game.View {
    public class DialogManager: GameObject {
        private AssetManager _am;
        
        // Food Dialogues
        private Dictionary<Food, Texture2D> eatDialogues;
        private Image dialogueImage;
        
        public DialogManager() {
            _am = DI.Get<AssetManager>();
            createMaps();
            dialogueImage = new Image(_am.dialogue_eat_apple);
            SetSize(dialogueImage.size);
            Add(dialogueImage);
            SetVisibility(false);
        }

        private void createMaps() {
            eatDialogues = new Dictionary<Food, Texture2D> {
                {Food.Apple, _am.dialogue_eat_apple},
                {Food.Blueberry, _am.dialogue_eat_bb},
                {Food.Milk, _am.dialogue_eat_milk},
                {Food.Grass, _am.dialogue_eat_grass},
            };
        }

        public void showDialogue(Food food) {
            dialogueImage.UpdateTextures(eatDialogues[food]);
            SetVisibility(true);
        }

        public void hideDialogue() {
            SetVisibility(false);
        }
    }
}