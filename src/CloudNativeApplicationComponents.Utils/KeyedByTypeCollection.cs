using System.Collections;
using System.Linq;

namespace CloudNativeApplicationComponents.Utils
{
    public class KeyedByTypeCollection : KeyedByTypeCollection<object>
    {
        public KeyedByTypeCollection() 
            : base()
        {
        }

        public KeyedByTypeCollection(IEnumerable items) 
            : base(items?.OfType<object>())
        {
        }
        public KeyedByTypeCollection(object[] items)
            : base(items)
        {
        }
    }
}
