﻿using RLNET;
using RogueSharp;
using System.Collections.Generic;

namespace RS_Roguelike
{
    // Our custom DungeonMap class extends the base RogueSharp Map class.
    public class DungeonMap : Map
    {
        public List<Rectangle> Rooms;

        public DungeonMap()
        {
            // Initialize the list of rooms when we create a new DungeonMap
            Rooms = new List<Rectangle>();
        }

        // Called by MapGenerator after we generate a new map.  It adds the player to the map.
        public void AddPlayer(Player player)
        {
            Game.Player = player;
            SetIsWalkable(player.X, player.Y, false);
            UpdatePlayerFieldOfView();
        }

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

        // Returns true when able to place the actor on the cell and false otherwise.
        public bool SetActorPosition(Actor actor, int x, int y)
        {
            // Only allow the actor placement if the cell is walkable.
            if(GetCell(x, y).IsWalkable)
            {
                // The cell the actor was on previously is now walkable.
                SetIsWalkable(actor.X, actor.Y, true);

                // Update the actor's position.
                actor.X = x;
                actor.Y = y;

                // The new cell the actor is on is now not walkable.
                SetIsWalkable(actor.X, actor.Y, false);

                // Don't forget to update the field-of-view if we just repositioned the player.
                if(actor is Player)
                {
                    UpdatePlayerFieldOfView();
                }
                return true;
            }
            return false;
        }

        // A helper method for setting the IsWalkable property on a cell.
        public void SetIsWalkable(int x, int y, bool isWalkable)
        {
            Cell cell = GetCell(x, y);
            SetCellProperties(cell.X, cell.Y, cell.IsTransparent, isWalkable, cell.IsExplored);
        }
    }
}
