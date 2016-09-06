using System;
using StupidPrincess.Renderables;

namespace StupidPrincess.Game.MainGame.Entities
{
    public class Door : StaticEntity
    {
        public Door(Position position) : base(position) {}
        public override string RenderedText => "D";
        public override ConsoleColor RenderedColor => Color.ConsoleColor;

        public LockColor Color { get; set; }
    }
}
