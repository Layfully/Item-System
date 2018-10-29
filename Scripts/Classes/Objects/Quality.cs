namespace AdrianGaborek.ItemSystem
{
    using System;
    using UnityEditor;
    using UnityEngine;

    [Serializable]
    public sealed class Quality : Object //, IISQuality
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _icon;

        public Quality()
        {
            _name = string.Empty;
            _icon = Sprite.Create(null, new Rect(), Vector2.zero);
        }

        public Quality(string name, Sprite icon)
        {
            Name = name;
            Icon = icon;
        }

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

        public override void Clone(IObject item)
        {
            Name = item.Name;
            Icon = item.Icon;
        }

        #region IDatabaseObject implementation
        public override void OnGUI()
        {
            Name = EditorGUILayout.TextField("Name", Name);
            Icon = EditorGUILayout.ObjectField("Icon", _icon, typeof(Sprite), false) as Sprite;
        }
        #endregion
    }
}

