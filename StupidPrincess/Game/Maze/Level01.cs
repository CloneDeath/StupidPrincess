using System;
using System.Collections.Generic;
using StupidPrincess.Game.MenuComponents;
using StupidPrincess.Renderables;

namespace StupidPrincess.Game.Maze
{
    public class Level01 : Renderable, ISubstate
    {
        public Level01() {
            Children = new IRenderable[] {
                new TextComponent("Level 01", new Position(0, 0)),
            };
        }

        public override IEnumerable<IRenderable> Children { get; }

        public void Update(TimeSpan deltaTime) {
            
        }
    }
}
