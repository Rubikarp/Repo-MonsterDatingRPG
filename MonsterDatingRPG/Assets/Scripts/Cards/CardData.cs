using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "new_CardData", menuName = "Scriptable/CardData", order = 1)]
public class CardData : ScriptableObject
{
    public CardContext context;
    public CardStat stats;
}
