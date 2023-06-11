using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Statistics", menuName = "ScriptableObjects/Game Statistics", order = 1)]
public class GameStatistics : ScriptableObject
{
    int dieCount = 0;
    public int DieCount { get { return dieCount; } set { dieCount = value < 0 ? 0 : value; } }
}
