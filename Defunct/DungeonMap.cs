﻿namespace RS_Roguelike.Core
{
    /*
        // Our custom DungeonMap class extends the base RogueSharp Map class.
        public class DungeonMap : Map
        {
            private readonly List<Monster> _monsters;

            public List<Rectangle> Rooms;

            public DungeonMap()
            {
                // Initialize the list of rooms when we create a new DungeonMap
                _monsters = new List<Monster>(); 
                Rooms = new List<Rectangle>();
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

            // Called by MapGenerator after we generate a new map.  It adds the player to the map.
            public void AddPlayer(Player player)
            {
                Game.Player = player;
                SetIsWalkable(player.X, player.Y, false);
                UpdatePlayerFieldOfView();
                Game.SchedulingSystem.Add(player);
            }

            public void AddMonster(Monster monster)
            {
                _monsters.Add(monster);
                // After adding the monster to the map, make sure that it's cell is not walkable.
                SetIsWalkable(monster.X, monster.Y, false);
                Game.SchedulingSystem.Add(monster);
            }

            public void RemoveMonster(Monster monster)
            {
                _monsters.Remove(monster);
                // After removing the monster from the map, make sure the cell is walkable again.
                SetIsWalkable(monster.X, monster.Y, true);
                Game.SchedulingSystem.Remove(monster);
            }

            public Monster GetMonsterAt(int x, int y)
            {
                return _monsters.FirstOrDefault(m => m.X == x && m.Y == y);
            }

            // A helper method for setting the IsWalkable property on a cell.
            public void SetIsWalkable(int x, int y, bool isWalkable)
            {
                Cell cell = GetCell(x, y);
                SetCellProperties(cell.X, cell.Y, cell.IsTransparent, isWalkable, cell.IsExplored);
            }

            // Look for a random location iin the room that is walkable.
            public Point GetRandomWalkableLocationInRoom(Rectangle room)
            {
                if (DoesRoomHaveWalkableSpace(room))
                {
                    for (int i = 0; i < 100; i++)
                    {
                        int x = Game.Random.Next(1, room.Width - 2) + room.X;
                        int y = Game.Random.Next(1, room.Height - 2) + room.Y;
                        if (IsWalkable(x, y))
                        {
                            return new Point(x, y);
                        }
                    }
                }

                // If we didn't find a walkable location in the room, return null.
                return null;
            }

            // Iterate through each Cell in the room and return true if any are walkable.
            public bool DoesRoomHaveWalkableSpace(Rectangle room)
            {
                for (int x = 1; x <= room.Width - 2; x++)
                {
                    for (int y = 1; y <= room.Height - 2; y++)
                    {
                        if (IsWalkable(x + room.X, y + room.Y))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }

            // The Draw method will be called each time that the map is updated.
            // It will render all of the symbols/colours for each cell to the map sub-console.
            public void Draw(RLConsole mapConsole, RLConsole statConsole)
            {
                foreach (Cell cell in GetAllCells())
                {
                    SetConsoleSymbolForCell(mapConsole, cell);
                }

                // Keep an index so we know which position to draw monster stats at.
                int i = 0;

                // Iteracte through each monster on the map and draw it after drawing the Cells.
                foreach (Monster monster in _monsters)
                {
                    if (IsInFov(monster.X, monster.Y))
                    {
                        monster.Draw(mapConsole, this);

                        // Pass in the index to DrawStats and increment it afterwards.
                        monster.DrawStats(statConsole, i);
                        i++;
                    }
                }
            }

            private void SetConsoleSymbolForCell(RLConsole console, Cell cell)
            {
                // When we haven't explored a cell yet, we don't want to draw anything.
                if (!cell.IsExplored)
                {
                    return;
                }

                // When a cell is currently in field-of-view, it should be drawn with lighter colours.
                if (IsInFov(cell.X, cell.Y))
                {
                    // Choose the symbol to be drawn based on if the cell is walkable or not.
                    // '.' for the floor and '#' for walls.
                    if (cell.IsWalkable)
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
                    if (!cell.IsWalkable)
                    {
                        console.Set(cell.X, cell.Y, Colors.Wall, Colors.WallBackground, '#');
                    }
                    if (_monsters.Any())
                    {
                        console.Set(cell.X, cell.Y, Colors.Floor, Colors.FloorBackground, '.');
                    }
                    else
                    {
                        console.Set(cell.X, cell.Y, Colors.Floor, Colors.FloorBackground, '.');
                    }
                }
            }
        }
    */
}
