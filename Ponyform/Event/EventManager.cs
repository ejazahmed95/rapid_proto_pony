using System;
using System.Collections.Generic;

namespace Ponyform.Event {
    public class EventManager {
        private Dictionary<GameEvent, List<Action<object>>> eventListeners;

        public EventManager(){
            eventListeners = new Dictionary<GameEvent, List<Action<object>>>();
        }

        /**
         * Register a function call for handling the event data
         */
        public void RegisterListener(GameEvent e, Action<object> listener){
            if (!eventListeners.TryGetValue(e, out var listeners)){
                eventListeners[e] = new List<Action<object>>();
                listeners = eventListeners[e];
            }
            listeners.Add(listener);
        }

        /**
         * SendEvent sends and any event related data
         */
        public void SendEvent(GameEvent e, object data = null){
            var listeners = eventListeners[e];
            foreach (var listener in listeners){
                listener(data);
            }
        }
    }
}