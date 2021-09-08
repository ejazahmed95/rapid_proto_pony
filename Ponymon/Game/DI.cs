using System;
using System.Collections.Generic;
using System.Linq;
using Ponyform.Utilities;

namespace Ponyform.Game
{
    public static class DI {
        private static Dictionary<Type, Object> instances = new Dictionary<Type, object>();

        static DI(){ 
            Logger.i("DI", "initializing the dependency injector");
        }
        
        /*
         * Register any type of class in the dependency manager
         */
        public static void Register<T>(T component){
            Logger.i("DI", $"Registering component type {typeof(T)}");
            instances[component.GetType()] = component;
        }

        /*
         * Get the object based on the type that has been previously registered
         */
        public static T Get<T>(){
            PrintDi();
            T i;
            try{
                i = instances.Select(component => component.Value).OfType<T>().FirstOrDefault();
            }
            catch (Exception e){
                Logger.i("DI", "exception in getting the game manager");
                return default;
            }
            Logger.i("DI", $"successfully got the type {typeof(T).FullName}");
            return i;
        }

        private static void PrintDi(){
            foreach (var (key, value) in instances){
                Logger.i("DI",$"Type={key}, Value={value}");
            }
        }
    }
}