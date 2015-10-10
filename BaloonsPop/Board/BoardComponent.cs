namespace PoppingBaloons.Board
{
    using PoppingBaloons.Interfaces;

    public abstract class BoardComponent
    {
        private bool isAcctive;

        public bool IsActive 
        {
            get
            {
                return this.isAcctive;
            }
            protected set
            {
                this.isAcctive = value;
            }
        }

        public abstract int GetValue();
    }
}