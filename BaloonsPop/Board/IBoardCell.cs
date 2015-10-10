namespace PoppingBaloons.Interfaces
{
    interface IBoardCell
    {
        int Row { get; set; }

        int Col { get; set; }

        string Color { get; set; }
    }    
}
