namespace PoppingBaloons.Board
{
    class BlueBalloon : BoardComponent
    {   
        private readonly int value = 2;

        public BlueBalloon()
        {
            this.IsActive = true;
            this.Color = "blue";
        }

        public override int GetValue()
        {
            return this.value;
        }       
    }
}
