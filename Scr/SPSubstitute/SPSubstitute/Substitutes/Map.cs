namespace SPSubstitute.Substitutes
{
    public interface IMap
    {
        void MapObjectValue(object value);
    }

    public abstract class Map : IMap
    {
        public void MapSpSubstituteValue(SpSubstitute value)
        {
            MapObjectValue(value.GetValueForMapping());
        }

        public abstract void MapObjectValue(object value);
    }
}
