using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sets same X position with player if camera doesn't see this object
/// </summary>
public class GroundFollower : MonoBehaviour
{
    [SerializeField]Transform TopPoint;
    [SerializeField] float MinDistance;

    Transform player;
    Transform camera;
    float bottomHeightPoint;
    float topPoint;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameManager.Instance.PlayerCamera.transform;
        player = GameManager.Instance.Player;
    }

    private void LateUpdate()
    {
        topPoint = TopPoint.position.y;
        //camera's bottom point
        bottomHeightPoint = MainTools.GetBottomOfCamera().y;
        if(bottomHeightPoint - MinDistance > topPoint)
        {
            Vector2 v = transform.position;
            v.x = player.position.x;
            transform.position = v;
        }
    }
}
