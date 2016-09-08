using System;
using System.Collections.Generic;
using StupidPrincess.Renderables;

namespace StupidPrincess.Game.MenuComponents
{
    public class TextComponent : IRenderable
    {
        public TextComponent(string text, Position position) {
            RenderedText = text;
            RenderPosition = position;
        }

        public string RenderedText { get; }
        public Position RenderPosition { get; }
        public IEnumerable<IRenderable> Children => new IRenderable[0];

        public ConsoleColor RenderedColor { get; set; } = ConsoleColor.Gray;
        public ConsoleColor BackgroundColor { get; set; } = ConsoleColor.Black;
    }
}
