using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;

public class MoveArea : MonoBehaviour
{
    [Button] public void Profile() => MoveAreaToIndex(-1);
    [Button] public void Swipe() => MoveAreaToIndex(0);
    [Button] public void Chat() => MoveAreaToIndex(1);

    [SerializeField] private float moveRange = 1170f;
    public void MoveAreaToIndex(int index)
    {
        var rect = (RectTransform)transform;
        rect.DOMove(rect.position + Vector3.right * moveRange * index, 0.5f).SetEase(Ease.InOutCirc);
    }
}
