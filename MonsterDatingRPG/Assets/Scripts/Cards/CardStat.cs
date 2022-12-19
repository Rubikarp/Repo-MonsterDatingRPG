using UnityEngine;

[System.Serializable]
public class CardStat
{
    [Range(0, 100)] public float Health = 50;
    [Space(10)]
    [Range(0, 10)] public float Mana = 5;
    [Range(0, 10)] public float ManaRegen = 5;
    [Space(10)]
    [Range(0, 100)] public float PhysicStrenght = 50;
    [Range(0, 100)] public float MentalStrenght = 50;
    [Range(0, 100)] public float PhysicDefense = 50;
    [Range(0, 100)] public float MentalDefense = 50;
}
