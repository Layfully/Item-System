using UnityEditor;
using UnityEngine;

namespace AdrianGaborek.ItemSystem
{
    public partial class ObjectDatabaseType<D, T> where D : ScriptableObjectDatabase<T> where T : Object, new()
    {
        private void LoadDatabase()
        {
            string databaseFullPath = @"Assets/" + _databasePath + "/" + _databaseName;

            _database = AssetDatabase.LoadAssetAtPath<D>(databaseFullPath);

            if (_database == null)
            {
                CreateDatabase(databaseFullPath);
            }
        }

        private void CreateDatabase(string databaseFullPath)
        {
            if (!AssetDatabase.IsValidFolder("Assets/" + _databasePath))
            {
                AssetDatabase.CreateFolder("Assets", _databasePath);
            }

            _database = ScriptableObject.CreateInstance<D>();
            AssetDatabase.CreateAsset(_database, databaseFullPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        public void Add(T item)
        {
            _database.Items.Add(item);
            EditorUtility.SetDirty(_database);
        }

        public void Insert(int index, T item)
        {
            _database.Items.Insert(index, item);
            EditorUtility.SetDirty(_database);
        }

        public void Remove(T item)
        {
            _database.Items.Remove(item);
            EditorUtility.SetDirty(_database);
        }

        public void Remove(int index)
        {
            _database.Items.RemoveAt(index);
            EditorUtility.SetDirty(_database);
        }

        public void Replace(int index, T item)
        {
            _database.Items[index] = item;
            EditorUtility.SetDirty(_database);
        }
        public int Count
        {
            get { return _database.Items.Count; }
        }
        public int GetIndex(string name)
        {
            return _database.Items.FindIndex(a => a.Name == name);
        }
        public T Get(int index)
        {
            return _database.Items[index];
        }
        public static U GetDatabase<U>(string databasePath, string databaseName) where U : ScriptableObject
        {
            string databaseFullPath = @"Assets/" + databasePath + "/" + databaseName;

            U database = AssetDatabase.LoadAssetAtPath<U>(databaseFullPath);

            if (database == null)
            {
                if (!AssetDatabase.IsValidFolder("Assets/" + databasePath))
                {
                    AssetDatabase.CreateFolder("Assets", databasePath);
                }

                database = ScriptableObject.CreateInstance<U>();
                AssetDatabase.CreateAsset(database, databaseFullPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }

            return database;
        }
    }
}