using UnityEditor;
using UnityEngine;

namespace AdrianGaborek.ItemSystem
{
    public partial class ObjectDatabaseType<D, T> where D : ScriptableObjectDatabase<T> where T : Object, new()
    {
        public void ItemDetails()
        {
            GUILayout.BeginVertical("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            GUILayout.BeginVertical("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            if (_showDetails)
            {
                _temporaryItem.OnGUI();
            }
            GUILayout.EndVertical();
            GUILayout.Space(50);
            GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
            DisplayButtons();
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
        }

        private void DisplayButtons()
        {
            if (_showDetails)
            {
                SaveButton();
                if (_selectedIndex != -1)
                {
                    DeleteButton();   
                }
                CancelButton();
            }
            else
            {
                CreateItemButton();
            }
        }

        private void CreateItemButton()
        {
            if (GUILayout.Button("Create " + _itemTypeName))
            {
                _temporaryItem = new T();
                _showDetails = true;
            }
        }

        private void SaveButton()
        {
            if (GUILayout.Button("Save"))
            {
                if (_selectedIndex == -1)
                {
                    Add(_temporaryItem);
                }
                else
                {
                    Replace(_selectedIndex, _temporaryItem);
                }
                _temporaryItem = null;
                _showDetails = false;
                _selectedIndex = -1;
                GUI.FocusControl(null);
            }
        }

        private void CancelButton()
        {
            if (GUILayout.Button("Cancel"))
            {
                _temporaryItem = null;
                _showDetails = false;
                GUI.FocusControl(null);
            }
        }

        private void DeleteButton()
        {
            if (GUILayout.Button("Delete"))
            {
                if (EditorUtility.DisplayDialog("Delete " + _itemTypeName,
                    "Are you sure that you want to delete " + _temporaryItem.Name,
                    "Delete", "Cancel"))
                {
                    Remove(_selectedIndex);

                    _temporaryItem = null;
                    _showDetails = false;
                    _selectedIndex = -1;
                    GUI.FocusControl(null);
                }
            }
        }
    }
}
