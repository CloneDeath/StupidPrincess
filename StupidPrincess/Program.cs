using StupidPrincess.Game;
using StupidPrincess.Renderables;
using StupidPrincess.Rendering;

namespace StupidPrincess
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var renderer = new ConsoleRenderer("Stupid Princess", new Size(128, 52));
            var game = new GameState();
            var timeKeeper = new TimeKeeper(10);
            while (!game.ShouldExit()) {
                var deltaTime = timeKeeper.WaitForUpdate();
                renderer.Render(game);
                game.Update(deltaTime);
            }
        }
    }
}
