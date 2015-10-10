namespace PoppingBaloons.Board
{
    class RedDecorator: BoardComponentDecorator
    {
        private const string Color = "red";

        public RedDecorator(BoardComponent component)
            :base(component)
        { 
        }

        public override void RenderComponent(Interfaces.IRenderer logger)
        {
            base.RenderComponent(logger);
        }
    }
}
