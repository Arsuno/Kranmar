using _Project.Source.Inventory.Item.ItemTypes;
using UnityEngine;

namespace _Project.Source.Enemy.Configs
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/Enemy Config")]
    public class EnemyConfig : ScriptableObject
    {
        [Header("Movement")]
        public float MoveSpeed = 3f;
        public float DetectionRadius = 10f;
        public float PathPointsRadius = 25f;

        [Header("Shooting")] 
        public Weapon Weapon;
        public float FireRate = 1f;
        public GameObject BulletPrefab;
    }
}