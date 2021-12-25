using System;

namespace DataStructure
{
    public class Item<TKye, TValue>
    {
        public TKye Key { get; set; }
        public TValue Value { get; set; }

        public Item() { }
        public Item(TKye key, TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Key = key;
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override bool Equals(object obj)
        {
            dynamic item = obj as Item<TKye,TValue>;
            return item.Key == Key && item.Value == Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}