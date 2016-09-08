using StupidPrincess.Renderables;

namespace StupidPrincess.Game.MainGame.Entities
{
    public class Wall : StaticEntity
    {
        public Wall(Position position) : base(position) { }
        public override string RenderedText => "#";
        public override bool Solid => true;
    }
}
