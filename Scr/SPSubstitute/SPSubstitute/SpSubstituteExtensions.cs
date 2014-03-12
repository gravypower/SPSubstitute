using SPSubstitute.Substitutes;

namespace SPSubstitute
{
    public static class SPSubstituteExtensions
    {
        public static void Returns<T>(this T value, Substitute returnThis, params T[] returnThese)
            where T : Map
        {
            value.MapSpSubstituteValue(returnThis);
        }

        public static void Returns<T>(this T value, object returnThis, params T[] returnThese)
            where T : IMap
        {
            value.MapObjectValue(returnThis);
        }
    }
}
