
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Mian.Scripts.Components.HealthComponent
{
    public class Health_View : MonoBehaviour
    {
        [SerializeField] private RectTransform CanvasHpBar;
        [SerializeField] private Image HPBarFieled;
        private Camera _camera;
        public void Awake()
        {
            _camera = Camera.main;
        }
        internal void UpdateView(int curenHp, int maxHp)
        {
            float fill = curenHp / (float)maxHp;
            HPBarFieled.fillAmount = fill;
        }
        private void LateUpdate()
        {
            if (CanvasHpBar != null && _camera != null)
            {
                CanvasHpBar.transform.LookAt(new Vector3(CanvasHpBar.transform.position.x, _camera.transform.position.y, _camera.transform.position.z));
                CanvasHpBar.transform.Rotate(0, 180, 0);

            }
        }
    }
}
