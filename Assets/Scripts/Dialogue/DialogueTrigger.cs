using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManager manager;
    
    private void Start() {
        manager = FindObjectOfType<DialogueManager>();
    }

    public void triggerDialogue()
    {
        manager.startDialogue(dialogue);
    }
}
