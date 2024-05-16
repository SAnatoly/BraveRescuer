using UnityEngine;

    public class Timer
    {
        public float _time;
        public string _timeText;

        public Timer(float time, string timeText)
        {
            _time = time;
            _timeText = timeText;
        }

        public void UpdateTime()
        {
            _time += Time.deltaTime;
        }
    }
