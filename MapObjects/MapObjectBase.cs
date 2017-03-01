using Microsoft.Xna.Framework;
using SadConsole;
using SadConsole.Effects;

namespace RS_Roguelike.MapObjects
{
    public abstract class MapObjectBase
    {
        public CellAppearance Appearance { get; set; }
        public ICellEffect EffectSeen { get; set; }
        public ICellEffect EffectHidden { get; set; }

        public MapObjectBase(Color foreground, Color background, int character)
        {
            Appearance = new CellAppearance(foreground, background, character);

            EffectSeen = new Recolor()
            {
                Foreground = Color.LightGray * 0.3f,
                Background = Color.LightGray * 0.3f,
                DoForeground = true,
                DoBackground = true,
                CloneOnApply = false
            };

            EffectHidden = new Recolor()
            {
                Foreground = Color.Black,
                Background = Color.Black,
                DoForeground = true,
                DoBackground = true,
                CloneOnApply = false
            };
        }

        public virtual void RenderToCell(SadConsole.Cell sadConsoleCell, bool isFov, bool isExplored)
        {
            Appearance.CopyAppearanceTo(sadConsoleCell);

            // Clear out the old effects if there are any.
            if (sadConsoleCell.Effect != null)
            {
                sadConsoleCell.Effect.Clear(sadConsoleCell);
                sadConsoleCell.Effect = null;
            }

            if (isFov)
            {
                // Do nothing if it is in view, it's a normal coloured square.
                // Possible to add light effects here?
            }
            else if (isExplored)
            {
                sadConsoleCell.Effect = EffectSeen;
                sadConsoleCell.Effect.Apply(sadConsoleCell);
            }
            else
            {
                sadConsoleCell.Effect = EffectHidden;
                sadConsoleCell.Effect.Apply(sadConsoleCell);
            }
        }

        public virtual void RemoveCellFromView(SadConsole.Cell sadConsoleCell)
        {
            // Clear out the old effects if there are any.
            if (sadConsoleCell.Effect != null)
            {
                sadConsoleCell.Effect.Clear(sadConsoleCell);
                sadConsoleCell.Effect = null;
            }

            sadConsoleCell.Effect = EffectSeen;
            sadConsoleCell.Effect.Apply(sadConsoleCell);
        }
    }
}
