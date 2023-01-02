using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeReaction : MonoBehaviour
{
    [SerializeField] private Image redFlag;
    [SerializeField] private Image greenFlag;

    [SerializeField] float maxAlpha = .33f;
    private void OnEnable()
    {
        redFlag.ChangeAlpha(0f);
        greenFlag.ChangeAlpha(0f);
    }

    public void SwipeReact(float value)
    {
        redFlag.ChangeAlpha(0f);
        greenFlag.ChangeAlpha(0f);

        float abs = Mathf.Abs(value);
        if (abs < .25f) return;

        bool isgreen = value < 0f;
        if (isgreen)
        {
            greenFlag.ChangeAlpha(Mathf.Lerp(0f, maxAlpha, Mathf.InverseLerp(.1f, .5f, abs)));
            redFlag.ChangeAlpha(0f);
        }
        else
        {
            redFlag.ChangeAlpha(Mathf.Lerp(0f, maxAlpha, Mathf.InverseLerp(.1f, .5f, abs)));
            greenFlag.ChangeAlpha(0f);
        }
    }

}
