using UnityEngine;
using NaughtyAttributes;

[System.Serializable]
public class CardContext
{
    public string name = "MonsterName";
    [ShowAssetPreview] public Sprite ProfilPicture;
    [Space(10)]
    [ResizableTextArea] public string description = "Look at this cool description";
}
