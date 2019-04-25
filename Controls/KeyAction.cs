using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hel.Controls
{
    public enum KeyAction
    {
        None = 0,

        Up,
        Down,
        Left,
        Right,

        Jump,
        Crouch,
        Dash,
        
        Pause,
        Menu,
        Settings,
        Exit,

        Inventory,
        Bag,
        Character,

        Action,
        Use,

        Yes,
        No,

        CycleItems,
        CycleAbilities,
    }
}
