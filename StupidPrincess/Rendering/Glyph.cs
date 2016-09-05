using System;

namespace StupidPrincess.Rendering
{
    public class Glyph
    {
        public Glyph(char character, ConsoleColor foreground, ConsoleColor background) {
            Character = character;
            ForegroundColor = foreground;
            BackgroundColor = background;
        }

        public char Character { get; }
        public ConsoleColor ForegroundColor { get; }
        public ConsoleColor BackgroundColor { get; }

        #region Equals

        public static bool operator ==(Glyph left, Glyph right) {
            return ReferenceEquals(left, right) || (!ReferenceEquals(left, null) && left.Equals(right));
        }

        public static bool operator !=(Glyph left, Glyph right) {
            return !(left == right);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(this, obj)) return true;
            var other = obj as Glyph;
            return !ReferenceEquals(other, null) && Equals(other);
        }

        protected bool Equals(Glyph other) {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(other, null)) return false;

            return Character == other.Character 
                && ForegroundColor == other.ForegroundColor 
                && BackgroundColor == other.BackgroundColor;
        }

        public override int GetHashCode() {
            return Character.GetHashCode() 
                + ForegroundColor.GetHashCode() 
                + BackgroundColor.GetHashCode();
        }

        #endregion
    }
}
