using System.Collections.Generic;

namespace StupidPrincess.Renderables
{
    public interface IRenderable
    {
        string RenderedText { get; }
        Position RenderPosition { get; }

        IEnumerable<IRenderable> Children { get; } 
    }

    public abstract class Renderable : IRenderable
    {
        public virtual string RenderedText => null;
        public virtual Position RenderPosition => new Position(0, 0);
        public virtual IEnumerable<IRenderable> Children => new IRenderable[0];
    }
}
