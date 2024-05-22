using System.Collections;
using Stats_system;
using TMPro;
using UnityEngine;

public class StatsView : MonoBehaviour
{
    public TMP_Text[] _scoreBarText;
    public Stats[] _stats;
 
    private void OnEnable()
    {

        StartCoroutine(GetStatistic());
        
        Debug.Log(_stats.Length);
    }

    public void Refresh()
    {
        for (int i = 0; i < _stats.Length; i++)
        {
            _scoreBarText[i].text = $"{_stats[i].name}     {_stats[i].time}";
        }
    }

    IEnumerator GetStatistic()
    {
      yield return  StartCoroutine(StatsController.GetStats());

      _stats = new Stats[StatsController.currentStats.Length];
      _stats = StatsController.currentStats;
      Refresh();
    }
}
