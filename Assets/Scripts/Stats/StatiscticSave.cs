using UnityEngine;

namespace Stats_system
{
    public class StatiscticSave: MonoBehaviour
    {
        [SerializeField] private Timer timer;
        
        public void SaveStats()
        {
            Stats stats = StatsController.newStats;
            Debug.Log(stats.name);
            stats.time = timer.GetTimerFormat();
            
            StatsController.SendStatsInServer(stats);
        }
    }
}