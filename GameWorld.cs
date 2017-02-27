using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Roguelike
{
    static class GameWorld
    {
        public static Consoles.DungeonScreen DungeonScreen;

        /// <summary>
        /// Called one time to initiate everything.  Assumes SadConsole has been set up and is ready to go.
        /// </summary>
        public static void Start()
        {
            DungeonScreen = new Consoles.DungeonScreen();
            SadConsole.Engine.ConsoleRenderStack.Add(DungeonScreen);
            DungeonScreen.MessageConsole.PrintMessage("SomeBODY once told me ...");
        }
    }
}
