using RLNET;
using RogueSharp;

namespace RS_Roguelike
{
    // Our custom DungeonMap class extends the base RogueSharp Map class.
    public class DungeonMap : Map
    {
        // The Draw method will be called each time that the map is updated.
        // It will render all of the symbols/colours for each cell to the map sub-console.
        public void Draw(RLConsole mapConsole)
        {
            mapConsole.Clear();
            foreach(Cell cell in GetAllCells())
            {
                SetConsoleSymbolForCell(mapConsole, cell);
            }
        }

        private void SetConsoleSymbolForCell(RLConsole console, Cell cell)
        {
            // When we haven't explored a cell yet, we don't want to draw anything.
            if(!cell.IsExplored)
            {
                return;
            }

            // When a cell is currently in field-of-view, it should be drawn with lighter colours.
            if(IsInFov(cell.X, cell.Y))
            {
                // Choose the symbol to be drawn based on if the cell is walkable or not.
                // '.' for the floor and '#' for walls.
                if(cell.IsWalkable)
                {
                    console.Set(cell.X, cell.Y, Colors.FloorFov, Colors.FloorBackgroundFov, '.');
                }
                else
                {
                    console.Set(cell.X, cell.Y, Colors.WallFov, Colors.WallBackgroundFov, '#');
                }
            }

            // When a cell is outside the field-of-view, draw it with darker colours.
            else
            {
                if(cell.IsWalkable)
                {
                    console.Set(cell.X, cell.Y, Colors.Floor, Colors.FloorBackground, '.');
                }
                else
                {
                    console.Set(cell.X, cell.Y, Colors.Wall, Colors.WallBackground, '#');
                }
            }
        }

        // This method will be called any time we move the player to update field-of-view.
        public void UpdatePlayerFieldOfView()
        {
            Player player = Game.Player;

            // Compute the field-of-view vased on the player's location and awareness.
            ComputeFov(player.X, player.Y, player.Awareness, true);

            // Mark all cells in field-of-view as having been explored.
            foreach (Cell cell in GetAllCells())
            {
                if (IsInFov(cell.X, cell.Y))
                {
                    SetCellProperties(cell.X, cell.Y, cell.IsTransparent, cell.IsWalkable, true);
                }
            }
        }
    }
}
