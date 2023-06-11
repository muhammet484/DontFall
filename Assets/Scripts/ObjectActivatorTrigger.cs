using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivatorTrigger : MonoBehaviour
{
    public GameObject _GameObject;
    [SerializeField, TextArea] string Note = "When 2d \"trigger\" collider enter event fire, this Game Object will be activated";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _GameObject.SetActive(true);
    }
}
