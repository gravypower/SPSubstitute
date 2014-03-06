namespace SPSubstitute.Substitutes
{
    public interface IMap
    {
        void MapValue(SpSubstitute value);

        void MapValue(object value);

        void DoMap(object value);
    }

    public abstract class Map : IMap
    {
        public void MapValue(SpSubstitute value)
        {
            MapValue(value.GetValueForMapping());
        }

        public abstract void MapValue(object value);

        public abstract void DoMap(object value);
    }
}
