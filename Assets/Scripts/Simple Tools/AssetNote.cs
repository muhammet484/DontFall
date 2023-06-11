using UnityEngine;

public class AssetNote : MonoBehaviour
{
    [Tooltip("This script does nothing. Only you can take some notes to assets.")]
    [TextArea(0, 5)]
    public string Note = "TODO: ";
    [TextArea(0, 5)]
    public string[] MultipleNotes;
}
