using System;
using System.Collections.Generic;
using StupidPrincess.Game.Input;
using StupidPrincess.Renderables;

namespace StupidPrincess.Game
{
    public class GameState : Renderable, IStateManager
    {
        private ISubstate _subState;
        protected Controls Control { get; } = new Controls();

        public GameState() {
            _subState = new MainMenuState(Control, this);
        }

        public bool ShouldExit() {
            return false;
        }

        public void Update(TimeSpan deltaTime) {
            Control.Update();
            _subState.Update(deltaTime);
        }

        public override IEnumerable<IRenderable> Children => new[] { _subState };

        public void SetState(ISubstate substate) {
            _subState = substate;
        }
    }

    public interface IStateManager
    {
        void SetState(ISubstate substate);
    }
}
