using StupidPrincess.Renderables;

namespace StupidPrincess.Game.MainGame.Entities
{
    public class Key : StaticEntity
    {
        public Key(Position position) : base(position) {}
        public override string RenderedText => "K";
    }
}
