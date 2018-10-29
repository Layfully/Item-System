namespace AdrianGaborek.ItemSystem
{
    public interface IWeapon : IItem
    {
        int MinDamage { get; set; }
        int Attack();
    }
}

