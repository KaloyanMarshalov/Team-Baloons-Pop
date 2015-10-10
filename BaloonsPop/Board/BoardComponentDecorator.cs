namespace PoppingBaloons.Board
{
    public abstract class BoardComponentDecorator : BoardComponent
    {
        protected BoardComponent decoratedComponent;

        public BoardComponentDecorator(BoardComponent component) 
        {
            this.decoratedComponent = component;
        }

        public override int GetValue()
        {
            return decoratedComponent.GetValue();
        }
    }
}