using ConsistentHashing.Core.Storage;
using System.Collections.Generic;
using System.Linq;

namespace ConsistentHashing.Core
{
    public class ConsistentHash
    {
        private readonly List<IStorageNode> _nodes = new List<IStorageNode>();
        public static readonly IStorageNode EmptyNode = new InMemoryNode(0);

        public ConsistentHash(IEnumerable<IStorageNode> nodes)
        {
            _nodes = new List<IStorageNode>(nodes);
        }

        public void AddNode(IStorageNode node)
        {

        }

        public void RemoveNode(IStorageNode node)
        {

        }

        public IStorageNode GetNode(long hash)
        {
            if(!_nodes.Any())
            {
                return EmptyNode;
            }

            IStorageNode prev = _nodes.First();
            foreach (var node in _nodes)
            {
                if (hash < node.Hash)
                {
                    break;
                }
                prev = node;
            }

            return prev;
        }
    }
}
