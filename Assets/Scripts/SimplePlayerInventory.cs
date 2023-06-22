using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SimplePlayerInventory
{
    static int twiceJumpAmount = 0;
    /// <summary>
    /// Can't be a negative number. You can use minus operator safely
    /// </summary>
    public int TwiceJumpAmount { get { return twiceJumpAmount; } set { 
            twiceJumpAmount = value > 0 ? value : 0;
            foreach (var act in onTwiceJumpAmountChanced)
                act();
        } 
    }
    HashSet<Action> onTwiceJumpAmountChanced = new HashSet<Action>();
    public void AddOnTwiceJumpAmountChanced(Action action) { onTwiceJumpAmountChanced.Add(action); }
    public void RemoveOnTwiceJumpAmountChanced(Action action) { onTwiceJumpAmountChanced.Remove(action); }
}
