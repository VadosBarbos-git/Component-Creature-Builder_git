using System;
using UnityEngine;

namespace Assets.Main.Scripts.Components.HealthComponent
{
    public class Health_Component : MonoBehaviour, IComponentEntity
    {

        public int curentHealth { get; private set; }
        public int maxHealth = 100;
        public bool imAlive => curentHealth > 0;
        public event Action<int, int> OnHealthChanged;

        private Health_View _View;

        public void TakeDamage(int damage)
        {
            curentHealth = Mathf.Max(curentHealth - damage, 0);
            OnHealthChanged?.Invoke(curentHealth, maxHealth);
        }
        public void Initialize(Entity entity)
        { 
            _View = GetComponent<Health_View>(); 
        }
        private void UpdateView(int curenHp, int maxHp)
        {
            if (_View != null) _View.UpdateView(curenHp, maxHp);
        }
        public void Tick()
        {

        }
        public void Disable()
        {
            OnHealthChanged -= UpdateView;
        }

        public void Activate()
        {
            curentHealth = maxHealth;
            OnHealthChanged += UpdateView;
            OnHealthChanged?.Invoke(curentHealth, maxHealth);
        }
    }
}