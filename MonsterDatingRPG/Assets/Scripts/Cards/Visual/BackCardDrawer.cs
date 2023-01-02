using NaughtyAttributes;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class BackCardDrawer : MonoBehaviour
{
    public CardObject card;

    public Slider HealthStat;
    public Slider ManaStat;
    public Slider ManaRegenStat;
    public Slider PhysicStrenghtStat;
    public Slider MentalStrenghtStat;
    public Slider PhysicDefenseStat;
    public Slider MentalDefenseStat;

    private void OnEnable()
    {
        Initialize();
    }

    [Button]
    private void Initialize()
    {
        HealthStat.minValue = 0;
        HealthStat.maxValue = 100;
        HealthStat.value = card.data.stats.Ego;

        MentalStrenghtStat.minValue = 0;
        MentalStrenghtStat.maxValue = 100;
        MentalStrenghtStat.value = card.data.stats.Beauty;

        PhysicDefenseStat.minValue = 0;
        PhysicDefenseStat.maxValue = 100;
        PhysicDefenseStat.value = card.data.stats.Chatter;

        MentalDefenseStat.minValue = 0;
        MentalDefenseStat.maxValue = 100;
        MentalDefenseStat.value = card.data.stats.Romantism;
    }
}
