using DialogueEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationController : MonoBehaviour
{

    public int ConversationStartCount = 0;
    public NPCConversation[] conversations;
    [SerializeField] GameObject InteractSpeakText;

    static void emptyAction() { }
    Action UpdateAction = emptyAction;
    public void OnConversationTriggerEnter(Collider2D collider)
    {
        if (collider.transform == GameManager.Instance.Player)
        {
            InteractSpeakText.SetActive(true);
            void checkButton()
            {
                if (Input.GetButtonDown("Submit"))
                {
                    InteractSpeakText.SetActive(false);
                    
                    NPCConversation conversation;
                    if (ConversationStartCount < conversations.Length)
                        conversation = conversations[ConversationStartCount];
                    else
                        conversation = conversations[conversations.Length - 1];
                    ConversationStartCount++;
                    ConversationManager.Instance.StartConversation(conversation);
                }
            }
            UpdateAction = checkButton;
        }
    }
    private void Update()
    {
        UpdateAction();
    }
    public void OnConversationTriggerExit(Collider2D collider)
    {
        if (collider.transform == GameManager.Instance.Player)
        {
            InteractSpeakText.SetActive(false);
            UpdateAction = emptyAction;
        }
    }
}
