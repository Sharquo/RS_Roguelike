using Microsoft.Xna.Framework;
using SadConsole.Consoles;

namespace RS_Roguelike.Utils
{
    class ConsoleBorders
    {
        public static  void DrawBar(int startX, int startY, int endX, int endY, int GlyphIndex, Console console)
        {
            SadConsole.Shapes.Line line = new SadConsole.Shapes.Line();
            line.StartingLocation = new Point(startX, startY);
            line.EndingLocation = new Point(endX, endY);
            line.CellAppearance.GlyphIndex = GlyphIndex;
            line.UseEndingCell = false;
            line.UseStartingCell = false;
            line.Draw(console);
        }
    }
}
