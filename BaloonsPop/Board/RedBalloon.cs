using System;

namespace PoppingBaloons.Board
{
    public class RedBalloon : BoardComponent
    {
        private readonly int value = 2;
        
        public RedBalloon()
        {
            this.IsActive = true;
            this.Color = "red";
        }        

        public override int GetValue()
        {
            return this.value;
        }        
    }
}