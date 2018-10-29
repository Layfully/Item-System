using UnityEditor;
using UnityEngine;

namespace AdrianGaborek.ItemSystem
{
    public partial class ObjectEditor : EditorWindow
    {
        private ObjectDatabaseType<WeaponDatabase, Weapon> _weaponDatabase = new ObjectDatabaseType<WeaponDatabase, Weapon>("WeaponDatabase.asset");
        private ObjectDatabaseType<ArmorDatabase, Armor> _armorDatabase = new ObjectDatabaseType<ArmorDatabase, Armor>("ArmorDatabase.asset");
        private ObjectDatabaseType<PotionDatabase, Potion> _potionDatabase = new ObjectDatabaseType<PotionDatabase, Potion>("PotionDatabase.asset");
        public  static ObjectDatabaseType<QualityDatabase, Quality> _qualityDatabase = new ObjectDatabaseType<QualityDatabase, Quality>("QualityDatabase.asset");

        private Vector2 _buttonSize = new Vector2(190, 25);
        private int _listViewWidth = 200;

        [MenuItem("Item System/Item System Editor %#i")]
        public static void Initialize()
        {
            ISObjectEditor window = GetWindow<ObjectEditor>();
            window.minSize = new Vector2(800, 600);
            window.titleContent.text = "Item System Database";
        }

        void OnEnable()
        {
            _weaponDatabase.OnEnable("Weapon");
            _armorDatabase.OnEnable("Armor");
            _potionDatabase.OnEnable("Potion");
            _qualityDatabase.OnEnable("Quality");

            _tabState = TabState.Weapon;
        }

        void OnGUI()
        {
            TopBar();
            GUILayout.BeginHorizontal();

            switch (_tabState)
            {
                case TabState.Weapon:
                    _weaponDatabase.OnGUI(_buttonSize, _listViewWidth);
                    break;
                case TabState.Armor:
                    _armorDatabase.OnGUI(_buttonSize, _listViewWidth);
                    break;
                case TabState.Potion:
                    _potionDatabase.OnGUI(_buttonSize, _listViewWidth);
                    break;
                case TabState.Quality:
                    _qualityDatabase.OnGUI(_buttonSize, _listViewWidth);
                    break;
                default:
                    break;
            }
            GUILayout.EndHorizontal();
            BottomBar();
        }
    }
}
