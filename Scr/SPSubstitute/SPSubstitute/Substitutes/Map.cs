namespace SPSubstitute.Substitutes
{
    public abstract class Map
    {
        public void MapValue(SpSubstitute value)
        {
            MapValue(value.GetValueForMapping());
        }

        public abstract void MapValue(object value);

        public abstract void DoMap(object value);
    }
}
