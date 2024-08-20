using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroController : MonoBehaviour {
    [SerializeField]
    private Animator fadeAnimator;
    [SerializeField]
    private Animator buttonAnimator;
    [SerializeField]
    private Animator titleAnimator;
    [SerializeField]
    private GameObject clickPrompt;
    [SerializeField] 
    private DialogueManager dialogueManager;
    
    private float startTime;
    private float timeToFade = 2f;

    private State state;
    // Start is called before the first frame update
    void Start() {
        startTime = Time.time;
        state = State.FADE_IN_TITLE;
    }

    private void Update() {
        switch (state) {
            case State.FADE_IN_TITLE:
                if (Time.time - startTime >= timeToFade) {
                    state = State.FADE_IN_BUTTON;
                    buttonAnimator.SetTrigger("FadeIn");
                    startTime = Time.time;
                }
                break;
            case State.FADE_IN_BUTTON:
                if (Time.time - startTime >= timeToFade) {
                    state = State.WAIT;
                    startTime = Time.time;
                    clickPrompt.GetComponent<Button>().interactable = true;
                }
                break;
            case State.FADE_OUT:
                if (Time.time - startTime >= timeToFade) {
                    dialogueManager.startDialogue(dialogueManager.introDialogue);
                    Destroy(gameObject);
                }
                break;
            case State.WAIT:
                break;
        }
    }

    public void ButtonClicked() {
        state = State.FADE_OUT;
        clickPrompt.GetComponent<Button>().interactable = false;
        buttonAnimator.SetTrigger("FadeOut");
        titleAnimator.SetTrigger("FadeOut");
        fadeAnimator.SetTrigger("FadeIn");
        startTime = Time.time;
    }
}

enum State {
    FADE_IN_TITLE,
    FADE_IN_BUTTON,
    FADE_OUT,
    WAIT
}
