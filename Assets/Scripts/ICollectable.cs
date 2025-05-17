using Bot;

public interface ICollectable
{
    public int UniqueID { get; }
    void Collect(IInventory inventory);
}