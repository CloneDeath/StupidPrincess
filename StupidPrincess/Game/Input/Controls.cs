using System;
using System.Collections.Generic;
using System.Linq;

namespace StupidPrincess.Game.Input
{
    public class Controls : IControls
    {
        private readonly List<ConsoleKey> _keysPressed = new List<ConsoleKey>();

        public void Update() {
            _keysPressed.Clear();

            while (Console.KeyAvailable) {
                var key = Console.ReadKey(true);
                _keysPressed.Add(key.Key);
            }
        }

        public bool AnyKeyPressed => _keysPressed.Any();

        public bool Up => _keysPressed.Contains(ConsoleKey.UpArrow);
        public bool Right => _keysPressed.Contains(ConsoleKey.RightArrow);
        public bool Left => _keysPressed.Contains(ConsoleKey.LeftArrow);
        public bool Down => _keysPressed.Contains(ConsoleKey.DownArrow);
    }

    public interface IControls
    {
        bool AnyKeyPressed { get; }

        bool Up { get; }
        bool Right { get; }
        bool Left { get; }
        bool Down { get; }
    }
}
