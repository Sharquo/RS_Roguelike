using SadConsole;
using Microsoft.Xna.Framework;
using SadConsole.Game;
using SadConsole.Consoles;

namespace RS_Roguelike.Consoles
{
    class MapConsole : SadConsole.Consoles.Console
    {
        GameObject playerEntity;

        public GameObject Player { get { return playerEntity; } }

        public MapConsole(int viewWidth, int viewHeight, int mapWidth, int mapHeight) : base(mapWidth, mapHeight)
        {
            TextSurface.RenderArea = new Rectangle(0, 0, viewWidth, viewHeight);

            AnimatedTextSurface playerAnimation = new AnimatedTextSurface("default", 1, 1, Engine.DefaultFont);
            playerAnimation.CreateFrame();
            playerAnimation.CurrentFrame[0].Foreground = Color.Orange;
            playerAnimation.CurrentFrame[0].GlyphIndex = '@';

            playerEntity = new GameObject(Engine.DefaultFont);
            playerEntity.Animation = playerAnimation;

            playerEntity.Position = new Point(1, 1);
        }

        public override void Render()
        {
            base.Render();
            playerEntity.Render();
        }

        public override void Update()
        {
            base.Update();
            playerEntity.Update();
        }
    }
}
