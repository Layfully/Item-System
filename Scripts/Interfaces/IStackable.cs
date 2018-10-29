namespace AdrianGaborek.ItemSystem
{
    public interface IStackable
    {
        int MaxStack { get; }
        int Stack(int amount);      //default value of 0
    }
}

