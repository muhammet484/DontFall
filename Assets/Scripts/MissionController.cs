using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionController : MonoBehaviour
{
    public Mission OldMansSwordMission = new Mission();

    public int CollectedMissionObject = 0;

    [SerializeField] ConversationController conversationController;
    [SerializeField] bool ShouldChangeConversation = false;
    [Tooltip("This conversations will be replaced after mission complete if \"should change conversation\" bool is true")]
    [SerializeField] NPCConversation[] ConversationsAfterMissionCompleted;

    [Tooltip("Debug purpose, for seeing the mission State")]
    string _missionStateString;

    private void Awake()
    {
        OldMansSwordMission.OnMissionStateChanged = OnMissionStateChanged;
    }

    void OnMissionStateChanged(MissionState missionState)
    {
        if(missionState == MissionState.MissionCompleted && ShouldChangeConversation)
        {
            conversationController.conversations = ConversationsAfterMissionCompleted;
            conversationController.ConversationStartCount = 0;
        }
        _missionStateString = missionState.ToString();
    }

    public void StartMission()
    {
        OldMansSwordMission.State = MissionState.MissionStarted;
    }
    public void MissionObjectCollected()
    {
        CollectedMissionObject++;
        if(CollectedMissionObject > 0)
        {
            OldMansSwordMission.State = MissionState.MissionCompleted;
        }
    }
    public void FailMission()
    {
        OldMansSwordMission.State = MissionState.MissionFailed;
    }
    public void MissionRewardReceived()
    {
        OldMansSwordMission.State = MissionState.MissionRewardReceived;
    }
}
