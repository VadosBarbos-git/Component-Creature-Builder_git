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
            curentHealth = maxHealth;
            _View = GetComponent<Health_View>();
            OnHealthChanged += UpdateView;
            OnHealthChanged?.Invoke(curentHealth, maxHealth);
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
            //остановить всю отрисовку перед удалением 
        }
    }
}