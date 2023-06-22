using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerFunctionOnTrigger : MonoBehaviour
{
    [SerializeField] UnityEvent<Collider2D> OnTriggerEnterRun;
    [SerializeField] UnityEvent<Collider2D> OnTriggerStayRun;
    [SerializeField] UnityEvent<Collider2D> OnTriggerExitRun;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTriggerEnterRun.Invoke(collision);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        OnTriggerStayRun.Invoke(collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        OnTriggerExitRun.Invoke(collision);
    }
}
