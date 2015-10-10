namespace PoppingBaloons.Board
{
    using PoppingBaloons.Interfaces;

    public abstract class BoardComponent
    {
        private bool isAcctive;
        private string color;

        public bool IsActive 
        {
            get
            {
                return this.isAcctive;
            }
            set
            {
                this.isAcctive = value;
            }
        }

        public string Color
        {
            get
            {
                return this.color;
            }
            set 
            {
                this.color = value;
            }
        }

        public abstract int GetValue();
    }
}