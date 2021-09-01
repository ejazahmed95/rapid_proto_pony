using Microsoft.Xna.Framework;

namespace Ponyform.Game.View {
    public struct PonyData {
        public Color bodyColor;
        public Color hairColor;
        public Color tailColor;
        public PonyHairStyle hairStyle;
        public PonyTailStyle tailStyle;
    }

    public enum PonyGroomPart {
        Body, Hair, Tail
    }

    public enum PonyHairStyle {
        HairStyle1,
        HairStyle2,
        HairStyle3,
        HairStyle4
    }

    public enum PonyTailStyle {
        TailStyle1,
        TailStyle2,
        TailStyle3,
        TailStyle4
    }
}