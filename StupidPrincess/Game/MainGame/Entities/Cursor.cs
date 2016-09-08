using System;
using System.Collections.Generic;
using StupidPrincess.Game.Input;
using StupidPrincess.Renderables;

namespace StupidPrincess.Game.MainGame.Entities
{
    public class Cursor : IEntity
    {
        public Cursor(IControls controls) {
            _controls = controls;
        }

        private TimeSpan _blinkTime = TimeSpan.Zero;
        private IControls _controls;

        public string RenderedText { get; private set; }
        public ConsoleColor RenderedColor => ConsoleColor.Black;
        public ConsoleColor BackgroundColor => ConsoleColor.White;
        public Position RenderPosition { get; private set; } = new Position(0, 0);
        public IEnumerable<IRenderable> Children => new IRenderable[0];

        public void Update(TimeSpan deltaTime) {
            UpdateCursorBlink(deltaTime);
            UpdatePosition();
        }

        private void UpdatePosition() {
            if (_controls.Down) {
                RenderPosition += Position.Down;
                _blinkTime = TimeSpan.Zero;
            }
            if (_controls.Left) {
                RenderPosition += Position.Left;
                _blinkTime = TimeSpan.Zero;
            }
            if (_controls.Right) {
                RenderPosition += Position.Right;
                _blinkTime = TimeSpan.Zero;
            }
            if (_controls.Up) {
                RenderPosition += Position.Up;
                _blinkTime = TimeSpan.Zero;
            }
        }

        private void UpdateCursorBlink(TimeSpan deltaTime) {
            _blinkTime += deltaTime;
            if (_blinkTime.TotalSeconds >= 0.6) {
                _blinkTime -= TimeSpan.FromSeconds(0.6);
            }
            if (_blinkTime < TimeSpan.FromSeconds(0.3)) {
                RenderedText = "X";
            } else if (_blinkTime < TimeSpan.FromSeconds(0.6)) {
                RenderedText = "";
            }
        }

        public bool Solid => false;
    }
}
