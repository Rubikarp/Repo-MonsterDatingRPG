using NaughtyAttributes;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class FrontCardDrawer : MonoBehaviour
{
    public CardObject card;

    public Image img;
    public TextMeshProUGUI nameSlot;
    public TextMeshProUGUI descSlot;

    private void OnEnable()
    {
        Initialize();
    }

    [Button]
    private void Initialize()
    {
        nameSlot.text = card.data.context.name;
        descSlot.text = card.data.context.description;

        img.sprite = card.data.context.ProfilPicture;
    }
}
