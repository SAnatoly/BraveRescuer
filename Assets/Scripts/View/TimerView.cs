using TMPro;
using UnityEngine;

namespace View
{
    public class TimerView: MonoBehaviour
    {
        [SerializeField] private TMP_Text _timerText;

        public void Visualisate(ITimerPresenter timerPresenter)
        {
            Refresh(timerPresenter);
        }

        public void Refresh(ITimerPresenter timerPresenter)
        {
            _timerText.text = timerPresenter.TimeText;
        }
    }
}