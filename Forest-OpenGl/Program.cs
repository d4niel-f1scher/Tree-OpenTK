using System;
using OpenTK.Windowing.Desktop;

namespace Forest_OpenGl
{
    class Program
    {    
        static void Main(string[] args)
        {
            int simulatedDays = 1500;
            PineTree pineTree = new PineTree();
            Game.GameEngine gameEngine = new Game.GameEngine(GameWindowSettings.Default, NativeWindowSettings.Default, pineTree, simulatedDays);

            gameEngine.Initialise();
            gameEngine.RunGameLoop();
        }
    }
}
