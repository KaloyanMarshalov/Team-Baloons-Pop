﻿namespace PoppingBaloons.Board
{
    using PoppingBaloons.Interfaces;

    public abstract class BoardComponent
    {
        public BoardComponent()
        {
            this.IsActive = true;
        }

        public bool IsActive { get; protected set; }

        public abstract void RenderComponent(IRenderer logger);
    }
}