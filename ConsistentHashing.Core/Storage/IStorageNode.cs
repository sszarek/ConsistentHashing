namespace ConsistentHashing.Core.Storage
{
    public interface IStorageNode
    {
        long Hash { get; }
        string Get(long hash);
        void Add(long hash, string value);
        void Remove(long hash);
    }
}
