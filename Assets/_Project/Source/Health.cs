using System;
using UnityEngine;

namespace _Project.Source
{
    public class Health : MonoBehaviour
    {
        public event Action<int> HealthChanged;
        
        [SerializeField] private int _maxValue;

        public int Value { get; private set; } = 10;
        

        public void GetDamage(int value)
        {
            Debug.Log(gameObject.name + " was damaged");
            
            if (Value - value > 0)
            {
                Value -= value;
                HealthChanged?.Invoke(Value);
            }
        }

        public void Heal(int value)
        {
            Debug.Log(gameObject.name + " was healed");
            
            if (Value + value <= _maxValue)
            {
                Value += value;
                HealthChanged?.Invoke(Value);
            }
        }
    }
}