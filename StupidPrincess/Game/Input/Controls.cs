using System;
using System.Collections.Generic;
using System.Linq;

namespace StupidPrincess.Game.Input
{
    public class Controls : IControls
    {
        private readonly List<ConsoleKey> _keyboardStates = new List<ConsoleKey>();

        public void Update() {
            _keyboardStates.Clear();

            while (Console.KeyAvailable) {
                var key = Console.ReadKey(true);
                _keyboardStates.Add(key.Key);
            }
        }

        public bool AnyKeyPressed => _keyboardStates.Any();
    }

    public interface IControls
    {
        bool AnyKeyPressed { get; }
    }
}
