using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hel.ECS.Components
{
    interface IMovement
    {
        float X { get; set; }
        float Y { get; set; }
    }
}
