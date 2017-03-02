using RS_Roguelike.Utils;
using SadConsole;
using SadConsole.Consoles;
using Microsoft.Xna.Framework;

namespace RS_Roguelike.Actors
{
    public class Player : Actor
    {
        public Player() : base(Engine.DefaultFont)
        {
            AnimatedTextSurface anim = new AnimatedTextSurface("default", 1, 1, Engine.DefaultFont);
            anim.CreateFrame();
            anim.CurrentFrame[0].Foreground = Colors.Player;
            anim.CurrentFrame[0].GlyphIndex = 64;

            Animation = anim;
            Position = new Point(1, 1);

            // Set the stats
            Attack = 2;
            AttackChance = 50;
            Awareness = 15;
            Defense = 2;
            DefenseChance = 40;
            Gold = 0;
            Health = 100;
            MaxHealth = 100;
            Name = "Chad";
            Speed = 10;
        }

    }
}
