using Microsoft.Xna.Framework.Graphics;
using Ponyform.UI;

namespace Ponyform.Game.View {
    public class PonyEyes: GameObject {
        private AssetManager _am;

        private Texture2D eye1, eye2, eye3;
        private Image eyeAnim;
        public PonyEyes(){
            _am = DI.Get<AssetManager>();
            eye1 = _am.pony_eye_1;
            eye2 = _am.pony_eye_2;
            eye3 = _am.pony_eye_3;
            eyeAnim = new Image(eye1, eye2, eye3, eye2);
            
            Add(eyeAnim);
        }

        public void Blink(int times){
            eyeAnim.Play(4, times);
        }
    }
}