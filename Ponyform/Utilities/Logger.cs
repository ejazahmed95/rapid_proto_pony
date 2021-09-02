﻿using System;
using System.Diagnostics;

namespace Ponyform.Utilities {
    public enum LogLevel {
        TRACE = 1,
        DEBUG = 2,
        INFO = 3,
        WARN = 4,
        ERROR = 5,
        FATAL = 6,
    }
	
    public static class Logger {
        private static LogLevel level = LogLevel.DEBUG;

        public static void setLogLevel(LogLevel l) {
            level = l;
        }
		
        public static void t(string tag, string message) {
            if (level > LogLevel.TRACE) return;
            Console.WriteLine($"[T] [{tag}]: {message}");
        }
		
        public static void d(string tag, string message) {
            if (level > LogLevel.DEBUG) return;
            Console.WriteLine($"[D] [{tag}]: {message}");
        }
		
        public static void i(string tag, string message) {
            if (level > LogLevel.INFO) return;
            Debug.WriteLine($"[I] [{tag}]: {message}");
        }
		
        public static void w(string tag, string message) {
            if (level > LogLevel.WARN) return;
            Console.WriteLine($"[W] [{tag}]: {message}");
        }
        public static void e(string tag, string message) {
            if (level > LogLevel.ERROR) return;
            Debug.WriteLine($"[E] [{tag}]: {message}");
        }
        public static void f(string tag, string message) {
            // if (level > LogLevel.INFO) return;
            Console.WriteLine($"[Fatal] [{tag}]: {message}");
        }
    }
}