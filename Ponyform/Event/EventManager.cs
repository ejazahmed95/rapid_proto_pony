using System.Collections.Generic;

namespace Ponyform.Event {
    public class EventManager {
        private Dictionary<GameEvent, List<IEventListener>> eventListeners;

        public EventManager(){
            eventListeners = new Dictionary<GameEvent, List<IEventListener>>();
        }

        public void RegisterListener(GameEvent e, IEventListener listener){
            if (!eventListeners.TryGetValue(e, out var listeners)){
                eventListeners[e] = new List<IEventListener>();
                listeners = eventListeners[e];
            }
            listeners.Add(listener);
        }

        public void SendEvent(GameEvent e, object data){
            var listeners = eventListeners[e];
            foreach (var listener in listeners){
                listener.OnGameEvent(data);
            }
        }
    }

    public enum GameEvent {
        Feed_Button_Clicked,
    }

    public interface IEventListener {
        void OnGameEvent(object data);
    }
}