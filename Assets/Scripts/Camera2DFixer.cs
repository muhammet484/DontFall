using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2DFixer : MonoBehaviour
{
    [SerializeField] Camera2D camera2D;
    [SerializeField, Range(0.01f, 1f)] float LookAhead = 0.4f;
    private void LateUpdate()
    {
        camera2D.lookAheadAmount = LookAhead;
    }
}
