using System;
using System.Collections.Generic;
using StupidPrincess.Game.MenuComponents;
using StupidPrincess.Renderables;

namespace StupidPrincess.Game.MainGame
{
    public class StatusBar : Renderable
    {
        private readonly TextComponent _health;
        private readonly TextComponent _magick;

        public StatusBar() {
            _health = new TextComponent("Health: 100", new Position(0, 0)) {
                RenderedColor = ConsoleColor.Gray,
                BackgroundColor = ConsoleColor.DarkRed
            };
            _magick = new TextComponent("Magick: 100", new Position(0, 1)) {
                RenderedColor = ConsoleColor.Gray,
                BackgroundColor = ConsoleColor.Blue
            };
        }

        public override IEnumerable<IRenderable> Children => new[] {
            _health, _magick
        };
    }
}
