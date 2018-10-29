using UnityEngine;

namespace AdrianGaborek.ItemSystem
{
    public partial class ObjectEditor
    {
        private enum TabState
        {
            Weapon,
            Armor,
            Potion,
            Quality
        }

        private TabState _tabState;

        void TopBar()
        {
            GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));
            WeaponTab();
            ArmorTab();
            PotionTab();
            QualityTab();
            GUILayout.EndHorizontal();
        }

        void WeaponTab()
        {
            if (GUILayout.Button("Weapons"))
            {
                _tabState = TabState.Weapon;
            }
        }

        void ArmorTab()
        {
            if (GUILayout.Button("Armors"))
            {
                _tabState = TabState.Armor;
            }
        }

        void PotionTab()
        {
            if (GUILayout.Button("Potions"))
            {
                _tabState = TabState.Potion;
            }
        }

        void QualityTab()
        {
            if (GUILayout.Button("Quality"))
            {
                _tabState = TabState.Quality;
            }
        }
    }
}

