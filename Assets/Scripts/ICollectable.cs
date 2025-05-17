using Bot;

public interface ICollectable
{
    public string Name { get; }
    void Collect(IInventory inventory);
}