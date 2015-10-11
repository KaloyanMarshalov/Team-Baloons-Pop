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
        void RenderGameboard(Gameboard gameboard);
    }
}