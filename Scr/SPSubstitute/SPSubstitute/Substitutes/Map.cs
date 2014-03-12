namespace SPSubstitute.Substitutes
{
    public abstract class Map : IMap
    {
        public void MapSpSubstituteValue(Substitute value)
        {
            MapObjectValue(value.GetValueForMapping());
        }

        public abstract void MapObjectValue(object value);
    }
}
