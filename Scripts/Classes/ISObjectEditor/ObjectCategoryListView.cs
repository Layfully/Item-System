/* 
ObjectCategoryListView.cs
April 27, 2018
Adrian Gaborek - Layfully
The partial class file that holds the code to populate and display the List View for the given database.
*/
using UnityEngine;

namespace AdrianGaborek.ItemSystem
{
    public partial class ObjectDatabaseType<D, T> where D : ScriptableObjectDatabase<T> where T : Object, new()
    {
        private int _selectedIndex = -1;                    //-1 means that we have nothing currently selected.
        private T _temporaryItem;                         //A temporal holder for the item we are currently working on.
        private bool _showDetails = false;                  //Flag to show that we are working on a new item.
        private Vector2 _scrollPosition = Vector2.zero;     //The position of the scrollbar for the list view.


        /// <summary>
        /// Lists the view.
        /// </summary>
        /// <param name="buttonSize">Button size</param>
        /// <param name="width">list width</param>
        public void ListView(Vector2 buttonSize, int width)
        {
            _scrollPosition = GUILayout.BeginScrollView(_scrollPosition, "Box", GUILayout.ExpandHeight(true), GUILayout.Width(width));

            for (int i = 0; i < _database.Count; i++)
            {
                if (GUILayout.Button(_database.Get(i).Name, "Box", GUILayout.Width(buttonSize.x),
                    GUILayout.Height(buttonSize.y)))
                {
                    _selectedIndex = i;
                    _temporaryItem = new T();
                    _temporaryItem.Clone(_database.Get(i));
                    _showDetails = true;
                }
            }
            GUILayout.EndScrollView();
        }
    }
}

