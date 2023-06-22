using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomlyFlipImage : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;
    void Start()
    {
        if (!sprite)
            TryGetComponent(out sprite);
        if(Random.value < 0.5f)
            sprite.flipX = true;
    }
}
