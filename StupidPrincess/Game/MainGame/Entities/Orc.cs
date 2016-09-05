using StupidPrincess.Renderables;

namespace StupidPrincess.Game.MainGame.Entities
{
    public class Orc : StaticEntity
    {
        public Orc(Position position) : base(position) { }
        public override string RenderedText => "O";
    }
}
