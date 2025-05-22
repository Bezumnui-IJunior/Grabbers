using Bot;

public interface ICollectable
{
    public int UniqueID { get; }
    public bool IsAlive { get; }

    void Collect(IInventory inventory);
}