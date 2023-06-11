using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwiceJump : CollectableObject
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        AddOnCollect(() =>
        {
            Inventory.TwiceJumpAmount++;
        });
    }
}
