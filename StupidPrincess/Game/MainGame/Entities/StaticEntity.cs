using System;
using System.Collections.Generic;
using StupidPrincess.Renderables;

namespace StupidPrincess.Game.MainGame.Entities
{
    public abstract class StaticEntity : IEntity
    {
        protected StaticEntity(Position position) {
            RenderPosition = position;
        }

        public abstract string RenderedText { get; }
        public virtual ConsoleColor RenderedColor => ConsoleColor.Gray;
        public virtual ConsoleColor BackgroundColor => ConsoleColor.Black;
        public Position RenderPosition { get; }
        public IEnumerable<IRenderable> Children => new IRenderable[0];

        public void Update(TimeSpan deltaTime) { }

        public virtual bool Solid => false;
    }
}
