using System;
using UnityEditor;
using UnityEngine;

namespace AdrianGaborek.ItemSystem
{
    [Serializable]
    public class Potion : Item, IPotion, IGameObject
    {
        [SerializeField] private int _healthAmount;
        [SerializeField] private int _manaAmount;
        [SerializeField] private GameObject _prefab;

        public Potion()
        {
            _healthAmount = 0;
            _manaAmount = 1;
        }

        public Potion(Potion potion)
        {
            Clone(potion);
        }

        public void Clone(Potion potion)
        {
            base.Clone(potion);

            HealthAmount = potion.HealthAmount;
            ManaAmount = potion.ManaAmount;
            _prefab = potion.Prefab;
        }

        #region IPotion implementation
        public int HealthAmount
        {
            get { return _healthAmount; }
            set { _healthAmount = value; }
        }

        public int ManaAmount
        {
            get { return _manaAmount; }
            set { _manaAmount = value; }
        }
        #endregion

        #region IGameObject implementation
        public GameObject Prefab
        {
            get { return _prefab; }
        }
        #endregion

        #region Editor Methods
        public override void OnGUI()
        {
            base.OnGUI();
            HealthAmount = EditorGUILayout.IntField("Health Amount", HealthAmount);
            ManaAmount = EditorGUILayout.IntField("Mana Amount", ManaAmount);
            DisplayPrefab();
        }

        public void DisplayPrefab()
        {
            _prefab = EditorGUILayout.ObjectField("Prefab", _prefab, typeof(GameObject), false) as GameObject;
        }
        #endregion
    }
}

