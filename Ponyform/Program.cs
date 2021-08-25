using System;

namespace Ponyform
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new PonyGame())
                game.Run();
        }
    }
}