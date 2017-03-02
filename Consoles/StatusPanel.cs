using Microsoft.Xna.Framework;
using RS_Roguelike.Actors;
using RS_Roguelike.Utils;
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

        public void DrawStats(Player player)
        {
            Print(1, 1, $"Name: {player.Name}", Colors.Text);
            Print(1, 3, $"Health: {player.Health}/{player.MaxHealth}", Colors.Text);
            Print(1, 4, $"Attack:   {player.Attack} ({player.AttackChance}%)", Colors.Text);
            Print(1, 5, $"Defense:  {player.Defense} ({player.DefenseChance}%)", Colors.Text);
            Print(1, 9, $"Gold: {player.Gold}", Colors.Gold);
        }
    }
}
