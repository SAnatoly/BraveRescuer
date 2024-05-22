using Stats_system;

namespace DefaultNamespace.Presenters.StatsPresenter
{
    public class StatsPresenter: IStatsPresenter
    {
        public Stats[] Stats { get; set; }
        
        public void GetStats(Stats[] stats)
        {
            Stats = stats;
        }
        
    }
}