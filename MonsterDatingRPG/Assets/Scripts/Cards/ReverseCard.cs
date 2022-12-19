using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using NaughtyAttributes;

public class ReverseCard : MonoBehaviour
{
    public bool isFront = true;
    [Space(10)]
    public GameObject front;
    public GameObject back;
    public float time = 1f;


    [Button]
    public void UnoReverseCard()
    {
        StopAllCoroutines();
        StartCoroutine(Reverse(time));
    }

    public IEnumerator Reverse(float duration)
    {
        if (isFront)
        {
            front.transform.DORotate(Vector3.up * 90, duration / 2).SetEase(Ease.InCirc);
        }
        else
        {
            back.transform.DORotate(Vector3.up * 90, duration / 2).SetEase(Ease.InCirc);
        }

        yield return new WaitForSeconds(duration / 2);

        if (isFront)
        {
            front.transform.SetSiblingIndex(0);
            back.transform.DORotate(Vector3.zero, duration / 2).SetEase(Ease.OutCirc);
        }
        else
        {
            back.transform.SetSiblingIndex(0);
            front.transform.DORotate(Vector3.zero, duration / 2).SetEase(Ease.OutCirc);
        }

        yield return new WaitForSeconds(duration / 2);

        isFront = !isFront;
    }
}
