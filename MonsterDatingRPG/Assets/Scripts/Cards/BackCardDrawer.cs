using NaughtyAttributes;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class BackCardDrawer : MonoBehaviour
{
    public SelectionCard card;

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
        HealthStat.value = card.data.stats.Health;

        ManaStat.minValue = 0;
        ManaStat.maxValue = 10;
        ManaStat.value = card.data.stats.Mana;
        ManaRegenStat.minValue = 0;
        ManaRegenStat.maxValue = 10;
        ManaRegenStat.value = card.data.stats.ManaRegen;

        PhysicStrenghtStat.minValue = 0;
        PhysicStrenghtStat.maxValue = 10;
        PhysicStrenghtStat.value = card.data.stats.PhysicStrenght;
        MentalStrenghtStat.minValue = 0;
        MentalStrenghtStat.maxValue = 100;
        MentalStrenghtStat.value = card.data.stats.MentalStrenght;

        PhysicDefenseStat.minValue = 0;
        PhysicDefenseStat.maxValue = 100;
        PhysicDefenseStat.value = card.data.stats.PhysicDefense;
        MentalDefenseStat.minValue = 0;
        MentalDefenseStat.maxValue = 100;
        MentalDefenseStat.value = card.data.stats.MentalDefense;
    }
}
