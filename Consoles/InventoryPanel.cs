using Microsoft.Xna.Framework;
using RS_Roguelike.Utils;
using SadConsole;
using SadConsole.Consoles;

namespace RS_Roguelike.Consoles
{
    class InventoryPanel : SadConsole.Consoles.Console
    {
        public InventoryPanel(string text, int width, int height) : base(width, height)
        {
            ConsoleBorders.DrawBar(0, 0, 0, height - 1, 179, this);

            ConsoleBorders.DrawBar(1, 0, width - 1, 0, 196, this);

            Print(2, 0, text);
        }
    }
}
