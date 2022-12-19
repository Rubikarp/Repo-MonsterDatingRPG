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
    [SerializeField, ReadOnly] private Vector2 _beginPos;
    [SerializeField, ReadOnly] private Vector2 _aimPos;
    [SerializeField, ReadOnly] private Quaternion _beginRot;

    [SerializeField, Range(0, 1)] private float swipeEdge = 0.75f;
    [SerializeField] private float lerpMoveSpeed = 8f;
    [SerializeField] private float lerpRotaSpeed = 8f;
    [SerializeField] private float bendAngle = 30;

    public UnityEvent<bool> OnSwipe;

    private void Awake()
    {
        transform.position = new Vector3(transform.position.x, Screen.height / 2, transform.position.z);
        _aimPos = _beginPos = transform.position;
        _beginRot = transform.rotation;
    }
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _aimPos, Time.deltaTime * lerpMoveSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, Mathf.Clamp(PositionRelativeToScreen(transform), -1, 1) * -bendAngle), Time.deltaTime * lerpRotaSpeed);
    }

    public void OnBeginDrag(PointerEventData eventData) { }
    public void OnDrag(PointerEventData eventData)
    {
        _aimPos = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        var centerDistance = ((_aimPos.x / Screen.width) - 0.5f) * 2;

        if (Mathf.Abs(centerDistance) > swipeEdge)
        {
            transform.SetSiblingIndex(0);

            _aimPos = _beginPos;
            //_aimPos += Mathf.Sign(centerDistance) * Vector2.right * Screen.width * 0.5f;

            transform.position = _beginPos;
            transform.rotation = Quaternion.identity;
            OnSwipe?.Invoke(Mathf.Sign(centerDistance) > 0);
        }
        else
        {
            _aimPos = _beginPos;
        }
    }

    /// <summary>
    /// Remap to -1 at the left edge, 0 at the center, 1 at the right edge
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    private float PositionRelativeToScreen(Transform entity) => (Camera.main.ScreenToViewportPoint(entity.position).x - 0.5f) * 2;
}
