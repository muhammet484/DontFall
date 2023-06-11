using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollisionDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform == GameManager.Instance.Player)
        {
            GameManager.Instance.PlayerDied();
        }
    }

    private void OnBecameVisible()
    {
        var pos = transform.position;
        pos.x = GameManager.Instance.Player.position.x;
        transform.position = pos;
    }
}
