using TMPro;
using UnityEngine;

namespace Stats_system
{
    public class NameSet: MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;

        public void SetName()
        {
            Stats stats = new Stats();
            stats.name = _inputField.text;
            StatsController.newStats= stats;
        }
    }
}