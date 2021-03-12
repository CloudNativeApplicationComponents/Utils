using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CloudNativeApplicationComponents.Utils
{
    public class KeyedByTypeCollection<TItem> : KeyedCollection<Type, TItem>
        where TItem : class
    {
        public KeyedByTypeCollection() : base(null, 4)
        {
        }

        public KeyedByTypeCollection(IEnumerable<TItem> items) : base(null, 4)
        {
            _ = items
                ?? throw new ArgumentNullException(nameof(items));

            foreach (TItem local in items)
            {
                base.Add(local);
            }
        }

        public T? Find<T>()
            where T : class, TItem
            => this.Find<T>(false);

        private T? Find<T>(bool remove)
            where T : class, TItem
        {
            for (int i = 0; i < base.Count; i++)
            {
                TItem item = base[i];
                if (item is T val)
                {
                    if (remove)
                    {
                        base.Remove(item);
                    }
                    return val;
                }
            }
            return default;
        }

        public Collection<T> FindAll<T>()
            where T : class, TItem
            => this.FindAll<T>(false);

        private Collection<T> FindAll<T>(bool remove)
            where T : class, TItem
        {
            Collection<T> collection = new Collection<T>();
            foreach (TItem local in this)
            {
                if (local is T value)
                {
                    collection.Add(value);
                }
            }
            if (remove)
            {
                foreach (T local2 in collection)
                {
                    base.Remove(local2);
                }
            }
            return collection;
        }

        protected override Type GetKeyForItem(TItem item)
        {
            _ = item
                ?? throw new ArgumentNullException(nameof(item));

            return item.GetType();
        }

        protected override void InsertItem(int index, TItem item)
        {
            _ = item
                ?? throw new ArgumentNullException(nameof(item));

            if (!base.Contains(item.GetType()))
            {
                base.InsertItem(index, item);
            }
            else
            {
                object[] args = new object[] { item.GetType().FullName };
                var msg = $"The value could not be added to the collection, as the collection already contains an item of the same type: '{args}'. This collection only supports one instance of each type.";
                throw new ArgumentException(msg);
            }
        }

        public T Remove<T>()
            where T : class, TItem
            => this.Find<T>(true);

        public Collection<T> RemoveAll<T>()
            where T : class, TItem
            => this.FindAll<T>(true);

        protected override void SetItem(int index, TItem item)
        {
            _ = item
                ?? throw new ArgumentNullException(nameof(item));

            base.SetItem(index, item);
        }

        public bool TryGetValue<T>(out T? value)
            where T : class, TItem
        {
            value = default;
            for (int i = 0; i < Count; i++)
            {
                TItem item = base[i];
                if (item is T val)
                {
                    value = val;
                    return true;
                }
            }
            return false;
        }
    }
}
