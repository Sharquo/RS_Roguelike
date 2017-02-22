using RS_Roguelike.Core;
using RS_Roguelike.Systems;

namespace RS_Roguelike.Interfaces
{
    public interface IBehavior
    {
        bool Act(Monster mosnter, CommandSystem commandSystem);
    }
}
