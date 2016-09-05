using System;
using System.Collections.Generic;
using StupidPrincess.Renderables;

namespace StupidPrincess.Game.MainGame.Entities
{
    public class Princess : IEntity
    {
        private Position _position;

        public Princess(Position startingPosition) {
            _position = startingPosition;
        }

        public string RenderedText => "P";
        public ConsoleColor RenderedColor => ConsoleColor.Magenta;
        public ConsoleColor BackgroundColor => ConsoleColor.Black;

        public Position RenderPosition => _position;
        public IEnumerable<IRenderable> Children => new IRenderable[0];

        public void Update(TimeSpan deltaTime) {
            
        }
    }
}
