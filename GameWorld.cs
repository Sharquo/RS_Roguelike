using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Roguelike
{
    static class GameWorld
    {
        public static Consoles.MapPanel MapPanel;

        /// <summary>
        /// Called one time to initiate everything.  Assumes SadConsole has been set up and is ready to go.
        /// </summary>
        public static void Start()
        {
            MapPanel = new Consoles.MapPanel();
            SadConsole.Engine.ConsoleRenderStack.Add(MapPanel);
            MapPanel.MessageConsole.PrintMessage("SomeBODY once told me ...");
        }
    }
}
