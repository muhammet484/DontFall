using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "Simple Inventory", menuName = "ScriptableObjects/Simple Inventory", order = 2)]
public class SimpleInventory : ScriptableObject
{
    [SerializeField] int twiceJumpAmount = 0;
    /// <summary>
    /// Can't be a negative number. You can use minus operator safely
    /// </summary>
    public int TwiceJumpAmount { get { return twiceJumpAmount; } set { twiceJumpAmount = value > 0 ? value : 0; } }
}
