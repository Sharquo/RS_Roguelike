using Microsoft.Xna.Framework;
using RS_Roguelike.Actors;
using RS_Roguelike.Utils;
using SadConsole;
using System;

namespace RS_Roguelike.Consoles
{
    class StatsConsole : SadConsole.Consoles.Console
    {
        public StatsConsole(int width, int height) : base(width, height)
        {
            // Draw the side bar
            ConsoleBorders.DrawBar(0, 0, 0, height - 1, 179, this);
        }

        public void DrawPlayerStats(Player player)
        {
            Print(1, 1, $"Name: {player.Name}", Colors.Text);
            Print(1, 3, $"Health: {player.Health}/{player.MaxHealth}", Colors.Text);
            Print(1, 4, $"Attack:   {player.Attack} ({player.AttackChance}%)", Colors.Text);
            Print(1, 5, $"Defense:  {player.Defense} ({player.DefenseChance}%)", Colors.Text);
            Print(1, 7, $"Gold: {player.Gold}", Colors.Gold);
        }

        public void DrawMonsterStats(Monster monster, int position)
        {
            // Start at Y=9 which is below the player stats.
            //Multiply the position by 2 to leave a space between each stat.
            int yPosition = 9 + (position * 2);

            // Begin the line by printing the symbol of the monster in the appropriate colour.
            Print(1, yPosition, monster.Symbol.ToString(), monster.color);

            // Figure out the width of the health bar by dividing the current health by max health.
            int width = Convert.ToInt32(((double)monster.Health / monster.MaxHealth) * 16.0);
            int remainingWidth = 16 - width;

            // Set the background colours of the health bars to show how damaged the monster is.
            ColoredString currentHealth = new ColoredString(width);
            ColoredString lostHealth = new ColoredString(remainingWidth);

            currentHealth.SetForeground(Swatch.Primary);
            lostHealth.SetBackground(Swatch.PrimaryDarkest);

            Print(3, yPosition, currentHealth);
            Print(3 + width , yPosition, lostHealth);

            // Print the monster's name over the top of the health bar.
            Print(2, yPosition, $": {monster.Name}", Swatch.DbLight);
        }
    }
}
