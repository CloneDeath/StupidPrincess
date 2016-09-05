using System;
using StupidPrincess.Renderables;

namespace StupidPrincess.Rendering
{
    public class ConsoleRenderer
    {
        public void Render(IRenderable target) {
            RenderTargetAndChildren(target);
        }

        private void RenderTargetAndChildren(IRenderable target) {
            foreach (var child in target.Children) {
                Render(child);
            }
            RenderToConsole(target);
        }

        private void RenderToConsole(IRenderable target) {
            if (target.RenderedText == null) return;

            Console.SetCursorPosition(target.RenderPosition.X, target.RenderPosition.Y);
            Console.Write(target.RenderedText);
        }
    }
}
