namespace SPSubstitute.Substitutes
{
    public interface IMap
    {
        void MapObjectValue(object value);
    }

    public abstract class Map : IMap
    {
        public void MapSpSubstituteValue(Substitute value)
        {
            MapObjectValue(value.GetValueForMapping());
        }

        public abstract void MapObjectValue(object value);
    }
}
