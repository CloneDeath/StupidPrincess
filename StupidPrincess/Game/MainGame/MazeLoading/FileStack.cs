using System.IO;
using System.Linq;
using StupidPrincess.Renderables;

namespace StupidPrincess.Game.MainGame.MazeLoading
{
    public class FileStack
    {
        private int _current;
        private readonly string[] _lines;

        public FileStack(string fileName) {
            _lines = File.ReadAllLines(fileName);
        }

        public string Current => _lines[_current];
        public Size MazeSize => new Size(RemainingLines.Max(l => l.Length), RemainingLines.Length);
        public string[] RemainingLines => _lines.Skip(_current + 1).ToArray();

        public void Advance() {
            _current++;
        }
    }
}
