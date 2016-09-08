using System;
using System.Collections.Generic;
using StupidPrincess.Game.Input;
using StupidPrincess.Game.MainGame;
using StupidPrincess.Game.MenuComponents;
using StupidPrincess.Renderables;

namespace StupidPrincess.Game
{
    public class MainMenuState : Renderable, ISubstate
    {
        private readonly IStateManager _stateManager;
        private readonly IControls _controls;

        public MainMenuState(IControls controls, IStateManager stateManager) {
            _controls = controls;
            _stateManager = stateManager;
            Children = new IRenderable[] {
                new TextComponent("Stupid Princess!", new Position(1, 1)), 
                new TextComponent("[Press Any Key to Begin!]", new Position(1, 3)) {
                    RenderedColor = ConsoleColor.Yellow
                },
            };
        }

        public override IEnumerable<IRenderable> Children { get; }

        public void Update(TimeSpan deltaTime) {
            if (_controls.AnyKeyPressed) {
                _stateManager.SetState(new Level01());
            }
        }
    }
}
