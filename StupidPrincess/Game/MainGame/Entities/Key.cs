using System;
using StupidPrincess.Renderables;

namespace StupidPrincess.Game.MainGame.Entities
{
    public class Key : StaticEntity
    {
        public Key(Position position) : base(position) {}
        public override string RenderedText => "K";
        public override ConsoleColor RenderedColor => Color.ConsoleColor;
        public override bool solid => false;

        public LockColor Color { get; set; }
    }
}
