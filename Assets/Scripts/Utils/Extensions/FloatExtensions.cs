using System;

namespace Assets.Scripts.Utils.Extensions
{
    public static class FloatExtensions
    {
        public static float Negative(this float value)
        {
            return -Math.Abs(value);
        }

        public static float Positive(this float value)
        {
            return Math.Abs(value);
        }
    }
}
