using UnityEngine.UI;

namespace Player.Health
{
    public class HealthVisualisation
    {
        private Image _healthBar;

        public void UpdateBar(float health)
        {
            _healthBar.fillAmount = health / 100;
        }
    }
}