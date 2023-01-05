using System;
using System.Collections.Generic;
using System.Collections;
using NaughtyAttributes;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class PlayerStats_Visual : MonoBehaviour
{
    [SerializeField] private PlayerLevel level;
    [SerializeField] private PlayerStats stats;
    [Space(10)]
    [SerializeField] private Slider[] sliders;
    [SerializeField] private TextMeshProUGUI[] textSlots;
    [Space(10)]
    [SerializeField] private TextMeshProUGUI upgradePointSlots;
    [SerializeField] private Button[] upgradesBtn;

    [Button]
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
            textSlots[i].text = currentStats.ToString();
        }
    }

    private void Update()
    {
        if (upgradePointSlots is not null)
        {
            upgradePointSlots.text = "Upgrade Point Available " + level.upgradePointAvailable.ToString();
        }
        foreach (var button in upgradesBtn)
        {
            button.interactable = level.upgradePointAvailable > 0;
        }

        for (int i = 0; i < sliders.Length; i++)
        {
            sliders[i].value = stats.GetStats((StatsType)(1 + i));
        }
    }
}