using System;

namespace PoppingBaloons.Board
{
    public class RedBalloon : BoardComponent
    {
        private readonly string color = "red";
        private readonly int value = 2;
        
        public RedBalloon()
        {
            this.IsActive = true;
        }

        public string Color {
            get
            {
                return this.color;
            }
        }

        public override int GetValue()
        {
            return this.value;
        }        
    }
}