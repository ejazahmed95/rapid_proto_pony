using Microsoft.Xna.Framework;

namespace Ponyform.Game.View {
    public class PonyData {
        public PonyState state = PonyState.IDLE;
        public Color bodyColor = Color.White;
        public Color hairColor = Color.White;
        public Color tailColor = Color.White;
        public PonyHairStyle hairStyle = PonyHairStyle.Default;
        public PonyTailStyle tailStyle = PonyTailStyle.Default;
    }

    public enum PonyState {
        IDLE, EATING, BEING_PET, HEAD_GROOMED, TAIL_GROOMED
    }

    public enum PonyGroomPart {
        Body, Hair, Tail
    }

    public enum PonyHairStyle {
        Default,
        HairStyle1,
        HairStyle2,
        HairStyle3,
        HairStyle4,
        HairStyle5
    }

    public enum PonyTailStyle {
        Default,
        TailStyle1,
        TailStyle2,
        TailStyle3,
        TailStyle4,
        TailStyle5
    }
}