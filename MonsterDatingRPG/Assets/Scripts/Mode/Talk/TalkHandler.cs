using System.Collections.Generic;
using System.Collections;
using NaughtyAttributes;
using UnityEngine;


public class TalkHandler : MonoBehaviour
{
    [SerializeField] private CardStats cardStats;
    [SerializeField] private PlayerStats playerStats;
    
    [SerializeField, Range(0,1)] private float talkRate = 0f;
    [SerializeField, Range(0,1)] private float dateRate = 0f;

    public void SetUpTalk(CardData data )
    {
    }

    private void OnDisable()
    {
    }
}