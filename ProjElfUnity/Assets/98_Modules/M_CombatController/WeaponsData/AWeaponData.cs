using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace ProjElf.CombatController
{
    public abstract class AWeaponData : ScriptableObject
    {
        [SerializeField, HideInInspector]
        private int m_weaponID = int.MinValue;
        public int WeaponID => m_weaponID;

        [System.Serializable]
        public class AWeaponSaveData
        {
            public string WeaponName;
            public Damage HitDamage;
            public float AttackSpeed;
            public int WeaponDataID;
            [System.NonSerialized]
            public AWeaponData WeaponData;
            public bool AllowContinueFiring;

            protected static string s_weaponLabel = "weapon";

            public AWeaponSaveData(AWeaponData weaponData)
            {
                WeaponName = weaponData.WeaponName;
                Random.InitState((new System.Random()).Next(0, 10000000));
                HitDamage = new Damage();
                HitDamage.HitDamage = Random.Range(weaponData.HitDamage.x, weaponData.HitDamage.y);
                HitDamage.DamageType = EDamageType.Physical;
                Random.InitState((new System.Random()).Next(0, 10000000));
                AttackSpeed = Random.Range(weaponData.AttackSpeed.x, weaponData.AttackSpeed.y);
                WeaponData = weaponData;
                AllowContinueFiring = weaponData.AllowContinueFiring;
                WeaponDataID = weaponData.WeaponID;
            }

            public void Unserialize()
            {
                Addressables.LoadAssetsAsync<AWeaponData>(s_weaponLabel,
                    null).Completed += obj =>
                    {
                        foreach (AWeaponData weaponData in obj.Result)
                        {
                            if (weaponData.WeaponID == WeaponDataID)
                            {
                                SetWeaponData(weaponData);
                            }
                        }

                    };
            }

            protected virtual void SetWeaponData(AWeaponData weaponData)
            {
                WeaponData = weaponData;
            }


        }
        //Var
        [SerializeField] protected string m_weaponName = string.Empty;
        [SerializeField] protected Sprite m_weaponSprite = null;
        [SerializeField] protected Vector2Int m_hitDamage = default;
        [SerializeField] protected Vector2 m_attackSpeed = default;
        [SerializeField] protected AWeapon m_weaponPrefab = null;
        [SerializeField] protected bool m_allowContinueFiring = false;
        public bool AllowContinueFiring => m_allowContinueFiring;
        public Vector2 AttackSpeed => m_attackSpeed;
        public Vector2Int HitDamage => m_hitDamage;
        public string WeaponName => m_weaponName;
        public Sprite WeaponSprite => m_weaponSprite;


        public AWeapon WeaponPrefab => m_weaponPrefab;

        internal virtual T GetWeaponSaveData<T>() where T : AWeaponSaveData
        {
            AWeaponSaveData weaponSaveData = new AWeaponSaveData(this);

            return (T)weaponSaveData;
        }

#if UNITY_EDITOR
        internal void GenerateRandomID()
        {
            m_weaponID = Random.Range(int.MinValue, int.MaxValue);
            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
#endif
    }

    [CustomEditor(typeof(AWeaponData), true)]
    internal class WeaponIDInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            AWeaponData targetWeaponData = (AWeaponData)target;
            GUILayout.Label("Weapon ID : " + targetWeaponData.WeaponID);
            if(GUILayout.Button("Generate Random ID"))
            {
                targetWeaponData.GenerateRandomID();
            }
        }
    }
}

