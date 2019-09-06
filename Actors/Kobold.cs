using RogueSharp.DiceNotation;
using RS_Roguelike.Core;
using RS_Roguelike.Utils;
using SadConsole;
using SadConsole.Consoles;

namespace RS_Roguelike.Actors
{
    public class Kobold : Monster
    {
        public Kobold(int level) : base(Engine.DefaultFont)
        {
            // Do the animation setting stuff.
            AnimatedTextSurface anim = new AnimatedTextSurface("default", 1, 1, Engine.DefaultFont);
            anim.CreateFrame();
            anim.CurrentFrame[0].Foreground = Colors.KoboldColor;

            Animation = anim;

            // Set the stats.
            int health = Dice.Roll("2D5");
            Attack = Dice.Roll("1D3") + level / 3;
            AttackChance = Dice.Roll("25D3");
            Awareness = 10;
            color = Colors.KoboldColor;
            Defense = Dice.Roll("1D3") + level / 3;
            DefenseChance = Dice.Roll("10D4");
            Gold = Dice.Roll("5D5");
            Health = health;
            MaxHealth = health;
            Name = "Kobold";
            Symbol = "k";
            Speed = 14;
        }
    }
}
