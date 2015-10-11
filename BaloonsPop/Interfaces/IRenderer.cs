// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRenderer.cs" company="Team-Baloon-Pop">
//   Team-Baloon-Pop
// </copyright>
// <summary>
//   Interface for Renderer classes
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PoppingBaloons.Interfaces
{
    using PoppingBaloons.Board;
    
    public interface IRenderer
    {
        void ClearScreen();

        void RenderGameboard(Gameboard gameboard);

        void RenderMessage(string score);
    }
}