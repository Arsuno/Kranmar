using UnityEngine;

namespace _Project.Source.Player
{
    public class Projectile : MonoBehaviour
    {
        private int _damage;
        private float _speed;
        private Vector3 _direction;

        public void Initialize(int damage, float speed, Vector3 direction)
        {
            _damage = damage;
            _speed = speed;
            _direction = direction;
            
            Destroy(gameObject, 5f);
        }

        private void Update()
        {
            transform.position += _direction * _speed * Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Health targetHealth))
            {
                targetHealth.GetDamage(_damage);
            }
        
            Destroy(gameObject);
        }
    }
}