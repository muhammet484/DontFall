using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollectable : CollectableObject
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        AddOnCollect(() =>
        {
            GameManager.Instance.IncreasePlayerHealthCount(1);
        });
    }
    
}
