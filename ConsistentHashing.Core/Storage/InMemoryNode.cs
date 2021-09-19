using System.Collections.Generic;

namespace ConsistentHashing.Core.Storage
{
    public class InMemoryNode : IStorageNode
    {
        private readonly Dictionary<long, string> _values = new Dictionary<long, string>();

        public InMemoryNode(long hash)
        {
            Hash = hash;
        }

        public long Hash
        {
            get;
        }

        public string Get(long hash)
        {
            return _values[hash];
        }

        public void Add(long hash, string value)
        {
            _values[hash] = value;
        }

        public void Remove(long hash)
        {
            _values.Remove(hash);
        }
    }
}
