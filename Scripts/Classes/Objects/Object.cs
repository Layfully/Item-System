using System;
using UnityEngine;

namespace AdrianGaborek.ItemSystem
{
    [Serializable]
    public abstract class Object : IObject
    {
        public abstract string Name { get; set; }

        public abstract Sprite Icon { get; set; }

        public abstract void Clone(IISObject item);

        public abstract void OnGUI();
    }
}

