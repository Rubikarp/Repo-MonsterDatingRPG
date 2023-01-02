using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "new_CardData", menuName = "Scriptable/CardData")]
public class CardData : ScriptableObject
{
    public CardContext context;
    public CardStats stats;
}
