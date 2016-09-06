using System;
using System.Collections.Generic;
using StupidPrincess.Game.MainGame.MazeLoading;
using StupidPrincess.Renderables;

namespace StupidPrincess.Game.MainGame
{
    public class Level01 : Renderable, ISubstate
    {
        private readonly Maze _maze;
        public Level01() {
            _maze = MazeLoader.Load("Game/MainGame/level01.txt");
        }

        public override IEnumerable<IRenderable> Children => new IRenderable[] {
            _maze
        };

        public void Update(TimeSpan deltaTime) {
            _maze.Update(deltaTime);
        }
    }
}
