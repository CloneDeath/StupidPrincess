using System;
using System.Collections.Generic;

namespace StupidPrincess.Renderables
{
    public interface IRenderable
    {
        string RenderedText { get; }
        ConsoleColor RenderedColor { get; }
        ConsoleColor BackgroundColor { get; }
        Position RenderPosition { get; }
        bool solid { get; }

        IEnumerable<IRenderable> Children { get; } 
    }

    public abstract class Renderable : IRenderable
    {
        public virtual string RenderedText => null;
        public virtual Position RenderPosition => new Position(0, 0);
        public virtual IEnumerable<IRenderable> Children => new IRenderable[0];

        public virtual ConsoleColor RenderedColor => ConsoleColor.Gray;
        public virtual ConsoleColor BackgroundColor => ConsoleColor.Black;

        public virtual bool solid => true;
    }
}
