using UnityEngine;

namespace AdrianGaborek.ItemSystem
{
    public partial class ObjectDatabaseType<D, T> where D : ScriptableObjectDatabase<T> where T : Object, new()
    {
        [SerializeField] private D _database;
        [SerializeField] private string _databaseName;
        [SerializeField] private string _databasePath = @"Database";
        [SerializeField] public string _itemTypeName = "Item";

        public ObjectDatabaseType(string name)
        {
            _databaseName = name;
        }

        public void OnEnable(string typeName)
        {
            _itemTypeName = typeName;

            if (_database == null)
            {
                LoadDatabase();
            }
        }

        public void OnGUI(Vector2 buttonSize, int width)
        {
            ListView(buttonSize, width);
            ItemDetails();
        }
    }
}

