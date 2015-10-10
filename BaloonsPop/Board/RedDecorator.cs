using System;

namespace PoppingBaloons.Board
{
    class RedDecorator: BoardComponentDecorator
    {
        public RedDecorator(BoardComponent component)
            :base(component)
        { 
        }
        public override int GetValue()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public override string GetColor()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
    }
}
