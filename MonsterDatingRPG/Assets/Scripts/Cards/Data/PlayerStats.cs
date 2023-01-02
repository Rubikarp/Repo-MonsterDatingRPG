using UnityEngine;

[System.Serializable]
public class PlayerStats
{
    [Range(0, 100)] public float ego = 50;
    [Range(0, 100)] public float beauty = 50;
    [Range(0, 100)] public float chatter = 50;
    [Range(0, 100)] public float romantism = 50;
}