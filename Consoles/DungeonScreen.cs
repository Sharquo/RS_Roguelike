using Microsoft.Xna.Framework;
using SadConsole.Consoles;
using SadConsole.Input;
using System;
using Console = SadConsole.Consoles.Console;

namespace RS_Roguelike.Consoles
{
    class DungeonScreen : ConsoleList
    {
        public MapConsole ViewConsole;
        public StatsConsole StatsConsole;
        public MessagePanel MessageConsole;
        public InventoryPanel InventoryConsole;

        private Console messageHeaderConsole;

        // The screen height and width are in the number of tiles. Not Used?
        private static readonly int _screenWidth = 100;
        private static readonly int _screenHeight = 100;

        // The map console takes up most of the screen and is where the map will be drawn.
        private static readonly int _mapWidth = 56;
        private static readonly int _mapHeight = 17;

        // Below the map console is the mesage console which displays attack rolls and other information.
        private static readonly int _messageWidth = 56;
        private static readonly int _messageHeight = 6;

        // The stat console is to the right of the map and displays player and monster stats.
        private static readonly int _statWidth = 24;
        private static readonly int _statHeight = 10;

        // Above the map is the inventory console which shows players equipment, abilites, and items.
        private static readonly int _inventoryWidth = 24;
        private static readonly int _inventoryHeight = 14;

        public DungeonScreen()
        {
            InventoryConsole = new InventoryPanel("Inventory", _inventoryWidth, _inventoryHeight + 1);
            StatsConsole = new StatsConsole(_statWidth, _statHeight);
            MessageConsole = new MessagePanel(_messageWidth, _messageHeight);
            ViewConsole = new MapConsole(_mapWidth, _mapHeight, _screenWidth, _screenHeight);
            //            InventoryConsole.FillWithRandomGarbage();

            // Setup the message header to be as wide as the screen but only 1 character high
            messageHeaderConsole = new Console(_messageWidth + 1, 1);
            messageHeaderConsole.DoUpdate = false;
            messageHeaderConsole.CanUseKeyboard = false;
            messageHeaderConsole.CanUseMouse = false;

            // Draw the line for the header
            messageHeaderConsole.Fill(Color.White, Color.Black, 196, null);

            // Print the header text
            messageHeaderConsole.Print(2, 0, " Messages ");

            // Move the rest of the consoles  into position (ViewConsole is already in position at 0).
            InventoryConsole.Position = new Point(56, _statHeight);
            StatsConsole.Position = new Point(56, 0);
            MessageConsole.Position = new Point(0, 18);
            messageHeaderConsole.Position = new Point(0, 17);

            // Add all consoles to this console list.
            Add(messageHeaderConsole);
            Add(StatsConsole);
            Add(ViewConsole);
            Add(MessageConsole);
            Add(InventoryConsole);

            SadConsole.Engine.ActiveConsole = this;

            // Keyboard stuff
            SadConsole.Engine.Keyboard.RepeatDelay = 0.07f;
            SadConsole.Engine.Keyboard.InitialRepeatDelay = 0.1f;
        }

        public override bool ProcessKeyboard(KeyboardInfo info)
        {
            if(info.KeysPressed.Contains(AsciiKey.Get(Microsoft.Xna.Framework.Input.Keys.Down)))
            {
                ViewConsole.MovePlayerBy(new Point(0, 1));
            }
            else if (info.KeysPressed.Contains(AsciiKey.Get(Microsoft.Xna.Framework.Input.Keys.Up)))
            {
                ViewConsole.MovePlayerBy(new Point(0, -1));
            }
            else if (info.KeysPressed.Contains(AsciiKey.Get(Microsoft.Xna.Framework.Input.Keys.Right)))
            {
                ViewConsole.MovePlayerBy(new Point(1, 0));
            }
            else if (info.KeysPressed.Contains(AsciiKey.Get(Microsoft.Xna.Framework.Input.Keys.Left)))
            {
                ViewConsole.MovePlayerBy(new Point(-1, 0));
            }
            return false;
        }
    }
}
