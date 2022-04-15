using System;

namespace Assets.Scripts.Utils.Extensions
{
    public static class GenericExtensions
    {
        public static void Let<T>(this T it, Action<T> lambda)
        {
            if (it == null) throw new ArgumentNullException(nameof(it));
            if (lambda == null) throw new ArgumentNullException(nameof(lambda));

            lambda.Invoke(it);
        }
    }
}
