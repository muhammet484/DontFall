using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectableObject : MonoBehaviour
{
    [SerializeField] protected ParticleSystem[] particles;

    [SerializeField]UnityEvent OnCollectEvent = new UnityEvent();

    HashSet<Action> OnCollect = new HashSet<Action>();
    protected void AddOnCollect(Action action) { OnCollect.Add(action); }
    protected void RemoveOnCollect(Action action) { OnCollect.Remove(action); }

    protected SimplePlayerInventory Inventory;

    // Start is called before the first frame update
    protected void Start()
    {
        AddOnCollect(OnCollectEvent.Invoke);

        Inventory = GameManager.Instance.PlayerInventory;

        //Erase object
        AddOnCollect(() =>
        {
            gameObject.SetActive(false);
        });

        //Show particle effects
        AddOnCollect(() =>
        {
            foreach (var particle in particles)
                particle.Play();
        });
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var action in OnCollect)
            action();
    }
}
