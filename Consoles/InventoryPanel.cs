using Microsoft.Xna.Framework;
using SadConsole;
using SadConsole.Consoles;

namespace RS_Roguelike.Consoles
{
    class InventoryPanel : SadConsole.Consoles.Console
    {
        public InventoryPanel(int width, int height) : base(width, height)
        {
            // Draw the side bar
            SadConsole.Shapes.Line side = new SadConsole.Shapes.Line();
            side.StartingLocation = new Point(0, 0);
            side.EndingLocation = new Point(0, height - 1);
            side.CellAppearance.GlyphIndex = 179;
            side.UseEndingCell = false;
            side.UseStartingCell = false;
            side.Draw(this);

            // Draw the top bar
            SadConsole.Shapes.Line top = new SadConsole.Shapes.Line();
            top.StartingLocation = new Point(1, 0);
            top.EndingLocation = new Point(width - 1, 0);
            top.CellAppearance.GlyphIndex = 196;
            top.UseEndingCell = false;
            top.UseStartingCell = false;
            top.Draw(this);
        }

        public InventoryPanel(string text, int width, int height) : base(width, height)
        {
            // Draw the side bar
            SadConsole.Shapes.Line side = new SadConsole.Shapes.Line();
            side.StartingLocation = new Point(0, 0);
            side.EndingLocation = new Point(0, height - 1);
            side.CellAppearance.GlyphIndex = 179;
            side.UseEndingCell = false;
            side.UseStartingCell = false;
            side.Draw(this);

            // Draw the top bar
            SadConsole.Shapes.Line top = new SadConsole.Shapes.Line();
            top.StartingLocation = new Point(1, 0);
            top.EndingLocation = new Point(width - 1, 0);
            top.CellAppearance.GlyphIndex = 196;
            top.UseEndingCell = false;
            top.UseStartingCell = false;
            top.Draw(this);

            Print(2, 0, text);
        }
    }
}
