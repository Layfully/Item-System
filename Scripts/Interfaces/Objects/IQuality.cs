using UnityEngine;

namespace AdrianGaborek.ItemSystem
{
    public interface IQuality : IObject
    {
        new string Name { get; set; }
        new Sprite Icon { get; set; }
    }
}
