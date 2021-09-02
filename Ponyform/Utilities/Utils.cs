using Microsoft.Xna.Framework;

namespace Ponyform.Utilities {
    public class Utils {
        public static bool TryConvertVal<A, B>(A obj, out B returnVal) {
            if (obj is B b) {
                returnVal = b;
                return true;
            }
            returnVal = default(B);
            return false;
        }

        public static Color debugColor = new Color(Color.Red, 0.3f);
    }
}