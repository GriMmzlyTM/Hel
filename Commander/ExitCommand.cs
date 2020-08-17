using System;
using System.Diagnostics;
using Hel.Commander.Model;
using Hel.ECS;
using Microsoft.Xna.Framework;

namespace Hel.Commander
{
    [Serializable]
    public class ExitCommand : ICommand
    {
        public void Execute()
        {
            Engine.Engine.worldManager.GetGame().Exit();
        }

        public void Undo()
        {
        }

    }
}