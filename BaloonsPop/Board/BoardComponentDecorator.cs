namespace PoppingBaloons.Board
{
    using System;
    using System.Linq;

    using PoppingBaloons.Interfaces;

    public abstract class BoardComponentDecorator : BoardComponent
    {
        protected BoardComponent decoratedComponent;

        public BoardComponentDecorator(BoardComponent component) 
        {
            this.decoratedComponent = component;
        }

        public override void RenderComponent(IRenderer logger)
        {
            decoratedComponent.RenderComponent(logger);
        }
    }
}