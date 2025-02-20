using UnityEngine;

namespace _Project.Source.Player
{
    public class WeaponFirePoint : MonoBehaviour
    {
        [SerializeField] private Transform _position;
        
        public Transform Position => _position;
    }
}