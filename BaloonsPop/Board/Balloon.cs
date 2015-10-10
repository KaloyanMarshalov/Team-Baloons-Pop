using System;
using PoppingBaloons.Interfaces;

namespace PoppingBaloons.Board
{
    class Balloon : BoardComponent
    {
        public const string RenderingSymbol = "O";

        public override void RenderComponent(IRenderer renderer)
        {
            //renderer.RenderGameboard(BaloonSymbol);
        }
    }
}