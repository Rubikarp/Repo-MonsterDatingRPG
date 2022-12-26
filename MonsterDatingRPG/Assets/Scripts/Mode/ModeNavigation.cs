using System.Collections.Generic;
using System.Collections;
using NaughtyAttributes;
using UnityEngine;
using DG.Tweening;

public enum Mode
{
    PROFILE = 0,
    SWIPE = 1,
    CHAT = 2,
}

public class ModeNavigation : MonoBehaviour
{
    public Mode currentMode = Mode.SWIPE;
    [Space(10)]
    [SerializeField] private RectTransform pannelProfile;
    [SerializeField] private RectTransform pannelSwipe;
    [SerializeField] private RectTransform pannelChat;

    [SerializeField] private float areaWidth = 540f;
    private RectTransform rect;

    private IEnumerator Start()
    {
        yield return new WaitForSecondsRealtime(.1f);
        rect = (RectTransform)transform;
        areaWidth = rect.rect.size.x;

        RefreshPosition();
    }

    [Button] public void Left() => MoveToMode(false);
    [Button] public void Right() => MoveToMode(true);

    public void MoveToMode(bool isRight)
    {
        var index = isRight ? (int)currentMode + 1 : (int)currentMode - 1;
        index = (index + 3) % 3;
        currentMode = (Mode)index;

        switch (currentMode)
        {
            case Mode.PROFILE:
                if (isRight)
                {
                    DoMoveToPos(pannelProfile, 0);
                    MoveToPos(pannelSwipe, 1);
                    DoMoveToPos(pannelChat, -1);
                }
                else
                {

                    DoMoveToPos(pannelProfile, 0);
                    DoMoveToPos(pannelSwipe, 1);
                    MoveToPos(pannelChat, -1);
                }
                break;
            case Mode.SWIPE:
                if (isRight)
                {
                    DoMoveToPos(pannelProfile, -1);
                    DoMoveToPos(pannelSwipe, 0);
                    MoveToPos(pannelChat, 1);
                }
                else
                {
                    MoveToPos(pannelProfile, -1);
                    DoMoveToPos(pannelSwipe, 0);
                    DoMoveToPos(pannelChat, 1);
                }
                break;
            case Mode.CHAT:
                if (isRight)
                {
                    MoveToPos(pannelProfile, 1);
                    DoMoveToPos(pannelSwipe, -1);
                    DoMoveToPos(pannelChat, 0);
                }
                else
                {
                    DoMoveToPos(pannelProfile, 1);
                    MoveToPos(pannelSwipe, -1);
                    DoMoveToPos(pannelChat, 0);
                }
                break;
            default:
                break;
        }
    }
    public void RefreshPosition()
    {
        switch (currentMode)
        {
            case Mode.PROFILE:
                MoveToPos(pannelProfile, 0);
                MoveToPos(pannelSwipe, 1);
                MoveToPos(pannelChat, -1);
                break;
            case Mode.SWIPE:
                MoveToPos(pannelProfile, -1);
                MoveToPos(pannelSwipe, 0);
                MoveToPos(pannelChat, 1);
                break;
            case Mode.CHAT:
                MoveToPos(pannelProfile, 1);
                MoveToPos(pannelSwipe, -1);
                MoveToPos(pannelChat, 0);
                break;
            default:
                break;
        }
    }
    public void MoveToPos(RectTransform rt, float position)
    {
        rt.SetLeft(-areaWidth * position);
        rt.SetRight(areaWidth * position);
    }
    public void DoMoveToPos(RectTransform rt, float position, float duration = .5f)
    {
        var myFloat = -rt.offsetMin.x;
        DOTween.To(() => myFloat, x => myFloat = x, position * areaWidth, duration).SetEase(Ease.InOutCirc)
        .OnUpdate(() =>
        {
            rt.SetLeft(-myFloat);
            rt.SetRight(myFloat);
        })
        .OnComplete(() => RefreshPosition());
    }

}
