using System.Collections.Generic;
using StupidPrincess.Renderables;

namespace StupidPrincess.Rendering
{
    public class Screen
    {
        private readonly Glyph[,] _glyphs;
        private readonly Size _size;

        public Screen(Size size) {
            _size = size;
            _glyphs = new Glyph[size.Width, size.Height];
        }

        public void Set(Position position, Glyph glyph) {
            _glyphs[position.X, position.Y] = glyph;
        }

        public Dictionary<Position, Glyph> GetDifferences(Screen other) {
            var ret = new Dictionary<Position, Glyph>();
            for (var x = 0; x < _size.Width; x++) {
                for (var y = 0; y < _size.Height; y++) {
                    if (_glyphs[x, y] == other._glyphs[x, y]) continue;

                    ret[new Position(x, y)] = _glyphs[x, y];
                }
            }
            return ret;
        } 
    }
}
