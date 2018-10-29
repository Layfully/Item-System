using System;
using UnityEngine;
using UnityEditor;

namespace AdrianGaborek.ItemSystem
{
    [Serializable]
    public class Weapon : Item, IWeapon, IDestructible, IGameObject
    {
        [SerializeField] private int _minDamage;
        [SerializeField] private int _durability;
        [SerializeField] private int _maxDurability;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private EquipmentSlot _equipmentSlot;

        public Weapon()
        {
            _minDamage = 0;
            _durability = 1;
            _maxDurability = 1;

            _equipmentSlot = EquipmentSlot.Feet;
        }

        public Weapon(Weapon weapon)
        {
            Clone(weapon);
        }

        public void Clone(Weapon weapon)
        {
            base.Clone(weapon);

            _minDamage = weapon.MinDamage;
            _durability = weapon.Durability;
            _maxDurability = weapon.MaxDurability;
            _equipmentSlot = weapon.EquipmentSlot;
            _prefab = weapon.Prefab;
        }

        #region IWeapon implementation
        public int MinDamage
        {
            get { return _minDamage; }
            set { _minDamage = value; }
        }

        public int Attack()
        {
            throw new System.NotImplementedException();
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

        public void Repair()
        {
            _maxDurability--;

            if (_maxDurability > 0)
            {
                _durability = MaxDurability;
            }
        }

        //not sure what to do with this method
        public void Destroy()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IISGameObject implementation
        public GameObject Prefab
        {
            get { return _prefab; }
        }
        #endregion

        public EquipmentSlot EquipmentSlot
        {
            get
            {
                return _equipmentSlot;
            }
        }

        #region Editor Methods
        //this code will og into new class later
        public override void OnGUI()
        {
            base.OnGUI();

            MinDamage = EditorGUILayout.IntField("Damage", MinDamage);
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
    }
}

