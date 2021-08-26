using System;
using System.Collections.Generic;
using System.Linq;
using Ponyform.Utilities;

namespace Ponyform.Game
{
    public static class DI {
        private static readonly Dictionary<Type, Object> instances = new Dictionary<Type, object>();

        static DI(){
            Logger.i("DI", "initializing the dependency injector");
        }
        public static void Register<T>(T component){
            instances[component.GetType()] = component;
        }

        public static T Get<T>(){
            Console.WriteLine("error in get");
            try{
                Logger.i("DI", "worked");
                var i = instances.Select(component => component.Value).OfType<T>().FirstOrDefault();
            }
            catch (Exception e){
                Logger.i("DI", "worked");
                Console.WriteLine("error getting");
                throw;
            }
            return default;
        }
    }
}