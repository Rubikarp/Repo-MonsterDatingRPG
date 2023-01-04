using System.Collections.Generic;
using System.Collections;
using NaughtyAttributes;
using UnityEngine;

public enum StatsType
{
    None = 0,
    Ego = 1,
    Beauty = 2,
    Chatter = 3,
    Romantism = 4,
}

public class PlayerStats : MonoBehaviour
{
    public EntityStats stats;

    [Button()]
    private void ResetStats()
    {
        stats.ego = 10f;
        stats.beauty = 10f;
        stats.chatter = 10f;
        stats.romantism = 10f;

        SaveStats();
    }
    
    [Button()] private void LoadStats()
    {
        stats.ego = PlayerPrefs.GetFloat(nameof(EntityStats.ego), 10f);
        stats.beauty = PlayerPrefs.GetFloat(nameof(EntityStats.beauty), 10f);
        stats.chatter = PlayerPrefs.GetFloat(nameof(EntityStats.chatter), 10f);
        stats.romantism = PlayerPrefs.GetFloat(nameof(EntityStats.romantism), 10f);
    }
    [Button()] public void SaveStats()
    {
        PlayerPrefs.SetFloat(nameof(EntityStats.ego), stats.ego);
        PlayerPrefs.SetFloat(nameof(EntityStats.beauty), stats.beauty);
        PlayerPrefs.SetFloat(nameof(EntityStats.chatter), stats.chatter);
        PlayerPrefs.SetFloat(nameof(EntityStats.romantism), stats.romantism);
    }


    public void UpgradeStat(int statsType) => UpgradeStat((StatsType)statsType);
    public void UpgradeStat(StatsType statsType, float value = 10f)
    {
        switch (statsType)
        {
            case StatsType.Ego:
                stats.ego += value;
                break;
            case StatsType.Beauty:
                stats.beauty += value;
                break;
            case StatsType.Chatter:
                stats.chatter += value;
                break;
            case StatsType.Romantism:
                stats.romantism += value;
                break;
        }

        SaveStats();
        
    }

    public float GetStats(StatsType statsType)
    {
        switch (statsType)
        {
            case StatsType.Ego:
                return stats.ego;
            case StatsType.Beauty:
                return stats.beauty;
            case StatsType.Chatter:
                return stats.chatter;
            case StatsType.Romantism:
                return stats.romantism;
            default:
                return 0f;
        }
    }
}