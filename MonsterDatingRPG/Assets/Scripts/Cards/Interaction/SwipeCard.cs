using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using NaughtyAttributes;
using DG.Tweening;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class SwipeCard : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Vector2 _beginPos => transform.parent.position;
    [SerializeField, ReadOnly] private Vector2 _aimPos;

    [SerializeField, Range(0, 1)] private float swipeEdge = 0.75f;
    [SerializeField] private float lerpMoveSpeed = 8f;
    [SerializeField] private float lerpRotaSpeed = 8f;
    [SerializeField] private float bendAngle = 30;

    public bool isSwipping = false;
    public UnityEvent<bool> onSwipe;
    public UnityEvent<float> onSwipping;

    private void Awake()
    {
        transform.position = new Vector3(transform.position.x, Screen.height / 2, transform.position.z);
        _aimPos = _beginPos;
    }
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, isSwipping ? _aimPos : _beginPos, Time.deltaTime * lerpMoveSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, Mathf.Clamp(PositionRelativeToScreen(), -1, 1) * bendAngle), Time.deltaTime * lerpRotaSpeed);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isSwipping = true;
    }
    public void OnDrag(PointerEventData eventData)
    {
        _aimPos = eventData.position;
        onSwipping?.Invoke(PositionRelativeToScreen());
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        isSwipping = false;

        var centerDistance = PositionRelativeToScreen();

        if (Mathf.Abs(centerDistance) > swipeEdge)
        {
            transform.SetSiblingIndex(0);
            _aimPos = _beginPos;
            transform.position = _beginPos;
            transform.rotation = Quaternion.identity;
            onSwipe?.Invoke(Mathf.Sign(centerDistance) > 0);
        }
        else
        {
            _aimPos = _beginPos;
        }
    }

    /// <summary>
    /// Remap to -1 at the left edge, 0 at the center, 1 at the right edge
    /// </summary>
    private float PositionRelativeToScreen() => ((transform.parent.position.x - transform.position.x) * 2f) / Screen.width;
}
