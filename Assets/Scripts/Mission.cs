using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MissionState
{
    MissionFailed ,MissionNotStarted, MissionStarted, MissionCompleted, MissionRewardReceived
}
public class Mission
{
    private MissionState _state = MissionState.MissionNotStarted;
    public MissionState State { get
        {
            return _state;
        }
        set
        {
            _state = value;
            OnMissionStateChanged(_state);
        }
    }

    public Mission() { }
    public Mission(Action<MissionState> onMissionStateChanged)
    {
        OnMissionStateChanged += onMissionStateChanged;
    }

    public Action<MissionState> OnMissionStateChanged = (a) => { };


}
