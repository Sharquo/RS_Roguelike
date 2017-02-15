using RLNET;

namespace RS_Roguelike
{
    class Game
    {
        // The screen height and width are in the nuumber of tiles.
        private static readonly int _screenWidth = 100;
        private static readonly int _screenHeight = 70;

        private static RLRootConsole _rootConsole;

        public static void Main()
        {
            // This must be the exact name of the bitmap font file we are using or it will error.
            string fontFileName = "terminal8x8.png";
            // The title will appear at the top of the console window.
            string consoleTitle = "RS_Roguelike";
            // Tell RLNet to use the bitmap font file that we specified and that each tile is 8 x 8 pixels.
            _rootConsole = new RLRootConsole(fontFileName, _screenWidth, _screenHeight, 8, 8, 1f, consoleTitle);
            // Set up a handler for RLnet's Update event.
            _rootConsole.Update += OnRootConsoleUpdate;
            // Set up a handler for RLNet's Render event.
            _rootConsole.Update += OnRootConsoleRender;
            // Begin RLNet's game loop.
            _rootConsole.Run();
        }

        // Event handler for RLNet's Update event.
        private static void OnRootConsoleUpdate(object sender, UpdateEventArgs e)
        {
            _rootConsole.Print(10, 10, "IT WORKED!", RLColor.White);
        }

        // Event handler for RLNet's Render event.
        private static void OnRootConsoleRender(object sender, UpdateEventArgs e)
        {
            // Tell RLNet to draw the console that we set.
            _rootConsole.Draw();
        }
    }
}
