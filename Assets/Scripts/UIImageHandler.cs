using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIImageHandler : MonoBehaviour
{
    [SerializeField] UIDocument uIDocument;
    [SerializeField] string ImageComponentId;
    [SerializeField] Texture2D sprite;

    private Image img;
    VisualElement root;
    private void Awake()
    {
    }

    private void OnEnable()
    {
        root = uIDocument.rootVisualElement;
        img = root.Q<Image>(ImageComponentId);
        img.image = sprite;
    }
}
