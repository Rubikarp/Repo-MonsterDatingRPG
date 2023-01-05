using UnityEngine;

[System.Serializable]
public class CardStats
{
    [Range(0, 10)] public int level = 1;

    [SerializeField] private EntityStats stats;
    public float Ego => stats.ego;
    public float Beauty => stats.beauty;
    public float Chatter => stats.chatter;
    public float Romantism => stats.romantism;
}
