﻿using StupidPrincess.Game;
using StupidPrincess.Rendering;

namespace StupidPrincess
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var renderer = new ConsoleRenderer("Stupid Princess", WindowSizingTool.GetWindowSize());
            var game = new GameState();
            var timeKeeper = new TimeKeeper(10);
            while (!game.ShouldExit()) {
                var deltaTime = timeKeeper.WaitForUpdate();
                renderer.Render(game);
                game.Update(deltaTime);
            }
        }
    }
}
