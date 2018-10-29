using System;
using UnityEngine;
#region using UnityEditor;
#if UNITY_EDITOR
using UnityEditor;
#endif
#endregion

namespace AdrianGaborek.ItemSystem
{
    [Serializable]
    public class Armor : Item, IArmor, IDestructible, IGameObject
    {
        [SerializeField] private int _armorLevel;
        [SerializeField] private int _durability;
        [SerializeField] private int _maxDurability;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private EquipmentSlot _equipmentSlot;

        public Armor()
        {
            _armorLevel = 0;
            _durability = 1;
            _maxDurability = 1;

            _equipmentSlot = EquipmentSlot.Feet;
        }

        public Armor(Armor armor)
        {
            Clone(armor);
        }

        public override void Clone(Object armor)
        {
            base.Clone(armor);

            Armor tempArmor = (Armor) armor;
            _armorLevel = tempArmor.ArmorLevel;
            _durability = tempArmor.Durability;
            _maxDurability = tempArmor.MaxDurability;
            _prefab = tempArmor.Prefab;
            _equipmentSlot = tempArmor._equipmentSlot;
        }

        #region IArmor implementation
        public int ArmorLevel
        {
            get { return _armorLevel; }
            set { _armorLevel = value; }
        }
        #endregion

        #region IDestructible implementation
        public int Durability
        {
            get { return _durability; }
        }

        public int MaxDurability
        {
            get { return _maxDurability; }
        }

        public void AdjustDurability(int amount)
        {
            _durability -= amount;

            if (_durability < 0)
            {
                _durability = 0;
            }

            if (_durability == 0)
            {
                Destroy();
            }
        }

        public void Destroy()
        {
            throw new NotImplementedException();
        }

        public void Repair()
        {
            _maxDurability--;

            if (_maxDurability > 0)
            {
                _durability = MaxDurability;
            }
        }
        #endregion

        #region IGameObject implementation
        public GameObject Prefab
        {
            get { return _prefab; }
        }
        #endregion

#if UNITY_EDITOR
        #region Editor methods
        //this code will og into new class later
        public override void OnGUI()
        {
            base.OnGUI();

            ArmorLevel = EditorGUILayout.IntField("Armor", ArmorLevel);
            _durability = EditorGUILayout.IntField("Durability", Durability);
            _maxDurability = EditorGUILayout.IntField("MaxDurability", MaxDurability);

            DisplayEquipmentSlot();
            DisplayPrefab();

        }

        public void DisplayEquipmentSlot()
        {
            _equipmentSlot = (EquipmentSlot)EditorGUILayout.EnumPopup("Equipment Slot", _equipmentSlot);
        }

        public void DisplayPrefab()
        {
            _prefab = EditorGUILayout.ObjectField("Prefab", _prefab, typeof(GameObject), false) as GameObject;
        }
        #endregion
#endif        
    }
}
