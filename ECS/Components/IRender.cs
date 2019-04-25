using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hel.ECS.Components
{
    public interface IRender
    {
        Texture2D texture { get; set; }
        float X { get; set; }
        float Y { get; set; }
    }
}
