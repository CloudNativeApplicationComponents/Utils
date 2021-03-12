using System.Collections;

namespace CloudNativeApplicationComponents.Utils
{
    public readonly struct AggregationContext
    {
        private readonly KeyedByTypeCollection _mementos;

        public AggregationContext(IEnumerable items)
        {
            _mementos = new KeyedByTypeCollection(items);
        }

        public T Find<T>()
            where T : class
        {
            return _mementos.Find<T>();
        }

        public AggregationContext Add<T>(T value)
            where T : class
        {
            _mementos.Add(value);
            return this;
        }
    }
}
