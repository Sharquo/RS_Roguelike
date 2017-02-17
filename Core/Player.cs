using RLNET;
using RogueSharp;

namespace RS_Roguelike.Core
{
    public class Player : Actor
    {
        public Player()
        {
            Awareness = 15;
            Name = "Chad";
            Color = Colors.Player;
            Symbol = '@';
            X = 10;
            Y = 10;
        }
    }
}
