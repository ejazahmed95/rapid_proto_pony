namespace Ponyform.Event {
    public struct EatingInfo {
        public Food foodItem;
    }

    public struct GroomInfo {
        public GroomPart groomPart;
    }

    public enum Food {
        Apple, Milk, Grass, Blueberry
    }

    public enum GroomPart {
        Hair, Body, Tail
    }
}