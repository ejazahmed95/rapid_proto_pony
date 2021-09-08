using Ponyform.Game.View;

namespace Ponyform.Event {
    public struct ActivitySelectInfo {
        public ActivityType type;
    }
    
    public struct EatingInfo {
        public Food foodItem;
    }

    public struct GroomInfo {
        public GroomPart groomPart;
        public PonyHairStyle ponyHairStyle;
        public PonyTailStyle ponyTailStyle;
    }

    public enum Food {
        Apple, Milk, Grass, Blueberry
    }

    public enum GroomPart {
        Hair, Body, Tail
    }


    
    public enum ActivityType {
        NONE, FEED, GROOM
    }
    
}