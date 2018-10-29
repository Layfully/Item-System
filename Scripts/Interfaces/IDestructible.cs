namespace AdrianGaborek.ItemSystem
{
    public interface IDestructible
    {
        int Durability { get; }
        int MaxDurability { get; }
        void AdjustDurability(int amount);
        void Destroy();
        void Repair();
    }
}

