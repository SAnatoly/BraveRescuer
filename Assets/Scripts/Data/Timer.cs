using UnityEngine;

    public class Timer: MonoBehaviour
    {
        public float _time;
        public void Update()
        {
            _time += Time.deltaTime;
        }
        
        public string GetTimerFormat()
        {
            float minutes = Mathf.FloorToInt(_time/60);
            float seconds = Mathf.FloorToInt(_time%60);

            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
