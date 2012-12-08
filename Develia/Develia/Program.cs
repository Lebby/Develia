using System;

namespace Develia
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Develia game = new Develia())
            {
                game.Run();
            }
        }
    }
#endif
}

