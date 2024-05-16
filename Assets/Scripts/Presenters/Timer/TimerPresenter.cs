using UnityEngine;


    public class TimerPresenter: ITimerPresenter
    {
        public string TimeText { get; private set; }
        public float Time { get; private set;}

        private readonly Timer _timer;
        
        public TimerPresenter(Timer timer)
        {
            _timer = timer;
        }

        private void Refresh()
        {
            Time = _timer._time;
            TimeText = GetTimerFormat(Time);
        }

        private string GetTimerFormat(float time)
        {
            float minutes = Mathf.FloorToInt(time/60);
            float seconds = Mathf.FloorToInt(time%60);

            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
