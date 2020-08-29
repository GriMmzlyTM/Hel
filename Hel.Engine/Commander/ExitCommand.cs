﻿using System;
using Hel.Engine.Commander.Model;

namespace Hel.Engine.Commander
{
    [Serializable]
    public class ExitCommand : ICommand
    {
        public void Execute()
        {
            Engine.WorldManager.GetGame().Exit();
        }

        public void Undo()
        {
        }
    }
}