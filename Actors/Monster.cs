using Microsoft.Xna.Framework;
using SadConsole;

namespace RS_Roguelike.Actors
{
    public class Monster : Actor
    {
        public int? TurnsAlerted { get; set; }

        public string Symbol { get; set; }
        public Color color { get; set; }
        public bool InFoV { get; set; }

        public Monster(Font font) : base(font)
        {

        }
/*
        public virtual void PerformAction(CommandSystem commandSystem)
        {
            var behavior = new StandardMoveAndAttack();
            behavior.Act(this, commandSystem);
        }
*/
    }
}
