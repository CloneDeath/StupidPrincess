using System;
using System.Collections.Generic;
using StupidPrincess.Renderables;

namespace StupidPrincess.Rendering
{
    public class ConsoleRenderer
    {
        private readonly Size _windowSize;
        private Screen _previousScreen;

        public ConsoleRenderer(string title, Size windowSize) {
            Console.Title = title;
            _windowSize = windowSize;
            _previousScreen = new Screen(windowSize);
            Console.SetWindowSize(windowSize.Width, windowSize.Height);
            Console.SetBufferSize(windowSize.Width, windowSize.Height);
            Console.CursorVisible = false;
        }

        public void Render(IRenderable target) {
            var newScreen = new Screen(_windowSize);
            RenderTargetAndChildren(target, newScreen, new Position(0, 0));

            var delta = newScreen.GetDifferences(_previousScreen);
            _previousScreen = newScreen;

            RenderChanges(delta);
        }

        private void RenderChanges(Dictionary<Position, Glyph> delta) {
            foreach (var glyph in delta) {
                Console.SetCursorPosition(glyph.Key.X, glyph.Key.Y);
                var toRender = glyph.Value?.Character ?? ' ';
                var forgroundColor = glyph.Value?.ForegroundColor ?? ConsoleColor.Gray;
                var backgroundColor = glyph.Value?.BackgroundColor ?? ConsoleColor.Black;
                Console.ForegroundColor = forgroundColor;
                Console.BackgroundColor = backgroundColor;
                Console.Write(toRender);
            }
        }

        private void RenderTargetAndChildren(IRenderable target, Screen screen, Position offset) {
            foreach (var child in target.Children) {
                RenderTargetAndChildren(child, screen, offset + target.RenderPosition);
            }
            RenderToScreen(target, screen, offset);
        }

        private static void RenderToScreen(IRenderable target, Screen screen, Position offset) {
            if (string.IsNullOrEmpty(target.RenderedText)) return;

            for (var i = 0; i < target.RenderedText.Length; i++) {
                screen.Set(target.RenderPosition + offset + new Position(i, 0), 
                    new Glyph(target.RenderedText[i],
                              target.RenderedColor,
                              target.BackgroundColor));
            }
        }
    }
}
