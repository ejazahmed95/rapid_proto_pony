using System.Collections.Generic;
using System.Data;
using Microsoft.Xna.Framework;

namespace Ponyform.Utilities {
    public class Scheduler {
        private List<Task> _tasks;
        
        public Scheduler(){
            _tasks = new List<Task>();
        }

        public void Update(GameTime gameTime){
            
        }
    }

    public class Task {
        
    }

    public class Utils {
        public static bool TryConvertVal<A, B>(A obj, out B returnVal) {
            if (obj is B b) {
                returnVal = b;
                return true;
            }
            returnVal = default(B);
            return false;
        }
    }
}