using UnityEngine;

namespace AdrianGaborek.ItemSystem
{
    public class EquipmentSlot : IEquipmentSlot
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _icon;

        public EquipmentSlot()
        {
            _name = "Name Me";
            _icon = Sprite.Create(null, new Rect(), Vector2.zero);
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Sprite Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }
    }
}

