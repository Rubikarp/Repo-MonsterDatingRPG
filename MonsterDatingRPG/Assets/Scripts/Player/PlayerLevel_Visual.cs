using NaughtyAttributes;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class PlayerLevel_Visual : MonoBehaviour
{
    [SerializeField] private PlayerLevel level;
    [Space(10)]
    [SerializeField] private Image fillImg;
    [SerializeField] private TextMeshProUGUI levelSlot;
    [Space(10)]
    [SerializeField, MinMaxSlider(0, 1)] private Vector2 xpBarBoundary = Vector2.right;

    private void Update()
    {

        if (fillImg is not null)
        {
            var ratio = (level.currentXp - level.prevLevelXp) / (level.nextLevelXp - level.prevLevelXp);
            fillImg.fillAmount = xpBarBoundary.x + ratio * (1 - (xpBarBoundary.x + (1 - xpBarBoundary.y)));
        }

        if (levelSlot is not null)
        {
            levelSlot.text = level.currentLevel.ToString();
        }

    }
}
