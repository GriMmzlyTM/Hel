using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hel.Toolkit
{
    internal class Convert
    {
        /// <summary>
        /// Converts boolean values to integers for math.
        /// TRUE = 1
        /// FALSE = 0
        /// </summary>
        /// <param name="val">Boolean value to check</param>
        /// <returns></returns>
        public static int BoolToInt(bool val)
        {
            return val ? 1 : 0;
        }
    }
}
