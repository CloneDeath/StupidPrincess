using System;

namespace StupidPrincess.Game.MainGame.Entities
{
    public class LockColor
    {
        public static readonly LockColor Red = new LockColor("Red", ConsoleColor.Red);
        public static readonly LockColor Blue = new LockColor("Blue", ConsoleColor.Blue);
        
        private LockColor(string colorName, ConsoleColor consoleColor) {
            _colorName = colorName;
            ConsoleColor = consoleColor;
        }

        private readonly string _colorName;
        public ConsoleColor ConsoleColor { get; }

        #region Equals

        public static bool operator ==(LockColor left, LockColor right) {
            return ReferenceEquals(left, right) || (!ReferenceEquals(left, null) && left.Equals(right));
        }

        public static bool operator !=(LockColor left, LockColor right) {
            return !(left == right);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(this, obj)) return true;
            var other = obj as LockColor;
            return !ReferenceEquals(other, null) && Equals(other);
        }

        protected bool Equals(LockColor other) {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(other, null)) return false;

            return _colorName == other._colorName;
        }

        public override int GetHashCode() {
            return _colorName.GetHashCode();
        }

        #endregion
    }
}
