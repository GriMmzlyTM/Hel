namespace Hel.Toolkit.Math
{
    public class ConversionUtil
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
