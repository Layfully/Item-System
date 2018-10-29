using UnityEngine;

namespace AdrianGaborek.ItemSystem
{
    public interface IObject
    {
        string Name { get; set; }
        Sprite Icon { get; set; }
        void Clone(IISObject item);

        //these go to other item interfaces
        //equip
        //questitem flag
        //durability
        //takedamge
        //prefab
    }
}

