using SPSubstitute.Substitutes;

namespace SPSubstitute
{
    public static class SpSubstituteExtensions
    {
        public static void Returns<T>(this T value, SpSubstitute returnThis, params T[] returnThese)
            where T : IMap
        {
            value.MapValue(returnThis);
        }

        public static void Returns<T>(this T value, object returnThis, params T[] returnThese)
            where T : IMap
        {
            value.MapValue(returnThis);
        }

    }
}
