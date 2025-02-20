using _Project.Source.Enemy.Configs;
using UnityEngine;

namespace _Project.Source.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private Vector3[] pathPoints; // Точки маршрута
        private int _currentPointIndex = 0;
        private float _moveSpeed;

        public void Initialize(EnemyConfig config)
        {
            _moveSpeed = config.MoveSpeed;
            
            pathPoints = EnemyPatrollingPointsGenerator.GeneratePathPoints(gameObject.transform.position, config.DetectionRadius);
        }

        public void StartPatrolling()
        {
            if (pathPoints.Length == 0) return;

            Vector3 targetPoint = pathPoints[_currentPointIndex];
            transform.position =
                Vector3.MoveTowards(transform.position, targetPoint, _moveSpeed * Time.deltaTime);
            transform.LookAt(targetPoint);

            if (Vector3.Distance(transform.position, targetPoint) < 0.2f)
            {
                _currentPointIndex = (_currentPointIndex + 1) % pathPoints.Length;
            }
        }
    }
}