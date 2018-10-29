using UnityEngine;

namespace AdrianGaborek.ItemSystem
{
    public interface IEquipmentSlot
    {
        string Name { get; set; }
        Sprite Icon { get; set; }
    }
}

