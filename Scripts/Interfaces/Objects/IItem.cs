using UnityEngine;

namespace AdrianGaborek.ItemSystem
{
    public interface IItem : IObject
    {
        int Value { get; set; }
        int Weight { get; set; }
        ISQuality Quality { get; set; }
    }
}
