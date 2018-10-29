using System;
using UnityEditor;
using UnityEngine;

namespace AdrianGaborek.ItemSystem
{
    [Serializable]
    public class Item : Object, IItem
    {
        [SerializeField] private string _name;
        [SerializeField] private int _value;
        [SerializeField] private int _weight;
        [SerializeField] private ISQuality _quality;
        [SerializeField] private Sprite _icon;

        #region Object implementation

        public override string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public override Sprite Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        public override void Clone(Object item)
        {
            Item tempItem = (Item)item;

            Name = tempItem.Name;
            Value = tempItem.Value;
            Weight = tempItem.Weight;
            Quality = tempItem.Quality;
            Icon = tempItem.Icon;
        }

        #endregion

        #region IItem implementation
        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public ISQuality Quality
        {
            get { return _quality; }
            set { _quality = value; }
        }
        #endregion

        #region Editor methods
        private int _qualitySelectedIndex = 0;
        private string[] _options;
        private ISObjectDatabaseType<ISQualityDatabase, ISQuality> _qualityDatabase;

        public override void OnGUI()
        {
            Name = EditorGUILayout.TextField("Name", Name);
            Value = EditorGUILayout.IntField("Value", Value);
            Weight = EditorGUILayout.IntField("Weight", Weight);
            DisplayIcon();
            DisplayQuality();
        }

        public void DisplayIcon()
        {
            _icon = EditorGUILayout.ObjectField("Icon", _icon, typeof(Sprite), false) as Sprite;
        }

        public int SelectedQualityIndex
        {
            get { return _qualitySelectedIndex; }
        }

        public void LoadQualityDatabase()
        {
            _qualityDatabase = ISObjectEditor._qualityDatabase;

            _options = new string[_qualityDatabase.Count];
            for (int i = 0; i < _qualityDatabase.Count; i++)
            {
                _options[i] = _qualityDatabase.Get(i).Name;
            }
        }

        public void DisplayQuality()
        {
            LoadQualityDatabase();
            int itemIndex = 0;

            if (_quality != null)
            {
                itemIndex = _qualityDatabase.GetIndex(_quality.Name);
            }

            if (itemIndex == -1)
            {
                itemIndex = 0;
            }
            _qualitySelectedIndex = EditorGUILayout.Popup("Quality", itemIndex, _options);
            _quality = _qualityDatabase.Get(SelectedQualityIndex);
        }
        #endregion
    }
}

