using System;
using System.Collections.Generic;
using System.Collections;
using NaughtyAttributes;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class PlayerStats_Visual : MonoBehaviour
{
    [SerializeField] private PlayerStats stats;

    [SerializeField] private Slider[] sliders;
    [SerializeField] private TextMeshProUGUI[] textSlots;

    private void OnEnable()
    {
        for (int i = 0; i < sliders.Length; i++)
        {
            sliders[i].maxValue = 100;
        }
        
        StatsType currentStats;
        for (int i = 0; i < textSlots.Length; i++)
        {
            currentStats = (StatsType)(i + 1);
            textSlots[i].text = nameof(currentStats);
        }
    }

    private void Update()
    {
        for (int i = 0; i < sliders.Length; i++)
        {
            sliders[i].value = stats.GetStats((StatsType)(1 + i));
        }
    }
}