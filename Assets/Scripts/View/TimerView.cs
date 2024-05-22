using TMPro;
using UnityEngine;

namespace View
{
    public class TimerView: MonoBehaviour
    {
        [SerializeField] private TMP_Text _timerText;
        [SerializeField] private Timer _timer;
        public void Update()
        {
            _timerText.text = _timer.GetTimerFormat();
        }
    }
}