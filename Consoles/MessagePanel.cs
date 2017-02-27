using SadConsole;
using SadConsole.Consoles;

namespace RS_Roguelike.Consoles
{
    class MessagePanel : SadConsole.Consoles.Console
    {

        public MessagePanel(int width, int height) : base(width, height)
        {
        }

        public void PrintMessage(string text)
        {
            ShiftDown(1);
            VirtualCursor.Print(text).CarriageReturn();
        }

        public void PrintMessage(ColoredString text)
        {
            ShiftDown(1);
            VirtualCursor.Print(text).CarriageReturn();
        }
    }
}
