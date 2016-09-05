using StupidPrincess.Renderables;

namespace StupidPrincess.Game.MenuComponents
{
    public class TextComponent : Renderable
    {
        public TextComponent(string text, Position position) {
            RenderedText = text;
            RenderPosition = position;
        }

        public override string RenderedText { get; }
        public override Position RenderPosition { get; }
    }
}
