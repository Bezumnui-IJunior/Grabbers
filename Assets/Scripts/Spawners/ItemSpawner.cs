namespace Spawners
{
    public class ItemSpawner<T> : Spawner<T>, IItemSpawner where T : Item, ISpawnable<T>
    {
        public new Item InstantiateObject() =>
            base.InstantiateObject();
    }
}