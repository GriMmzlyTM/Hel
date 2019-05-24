using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hel.ECS.Components;
using Microsoft.Xna.Framework.Graphics;

namespace Hel.ECS.Entities.Tests
{
    public struct Character : IEntity, IRender, IMovement
    {
        public uint Id { get; set; }
        public bool Active { get; set; }
        public Texture2D Texture { get; set; }
        public float X { get; set; }
        public float Y { get; set; }

    }
}
