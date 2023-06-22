using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameStatistics
{
    static int dieCount = 0;
    public int DieCount { get { return dieCount; } set { dieCount = value < 0 ? 0 : value; } }
}
