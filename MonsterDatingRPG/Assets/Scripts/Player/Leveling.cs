using System.Collections.Generic;
using System.Collections;
using NaughtyAttributes;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Leveling : MonoBehaviour
{
    [SerializeField, Min(1)] public int currentLevel = 1;
    [SerializeField] public float currentXp = 0f;
    [SerializeField] public float prevLevelXp = 0f;
    [SerializeField] public float nextLevelXp = 100f;
    [Space(10)]
    [SerializeField] public float duration = .5f;
    [SerializeField] public Ease easeType = Ease.InOutSine;
    [Space(10)]
    public UnityEvent onLevelUp;

    [Button] private void GainXP_100() => GainXP(100f);
    public void GainXP(float value)
    {
        DOTween
            .To(() => currentXp, x => currentXp = x, currentXp + value, duration)
            .SetEase(easeType)
            .OnUpdate(() => CheckLevelUp())
            .OnComplete(() => CheckLevelUp());
    }

    private void CheckLevelUp()
    {
        if (currentXp >= nextLevelXp)
        {
            currentLevel++;
            onLevelUp?.Invoke();

            prevLevelXp = nextLevelXp;
            //Next level 150%
            nextLevelXp += nextLevelXp * 0.33f;
        }
    }

}
