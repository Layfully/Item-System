namespace AdrianGaborek.ItemSystem
{
    public interface IPotion : IItem
    {
        int HealthAmount { get; set; }
        int ManaAmount { get; set; }
    }
}

