using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour {
	[SerializeField]
	AdditiveSceneChanger sceneChanger;

	private Animator fadeAnimator;
	private TrackDay dayTracker;
	[SerializeField]
	DialogueTrigger[] dialogueTriggers;

	private bool isDialogueOpen;

	private static readonly int IsOpen = Animator.StringToHash("isOpen");

	private float timeStartEndLevel;
	private float timeTilDialogue = 2f;
	private bool isWaitingDialogue;
	
	private float timeStartFade;
	private float totalFadeTime = 2f;
	private bool isFading;

	private void Start() {
		fadeAnimator = GameObject.FindGameObjectWithTag("Fade").GetComponent<Animator>();
		dayTracker = GameObject.FindGameObjectWithTag("DayManager").GetComponent<TrackDay>();
	}

	private void Update() {

		if (isWaitingDialogue && Time.time - timeStartEndLevel > timeTilDialogue) {
			// trigger dialogue cutscene
			dialogueTriggers[dayTracker.currentDay].triggerDialogue();
			isDialogueOpen = true;
			isWaitingDialogue = false;
		}

		if (isDialogueOpen) {
			isDialogueOpen = dialogueTriggers[dayTracker.currentDay].manager.animator.GetBool(IsOpen);

			if (!isDialogueOpen) {
				fadeAnimator.SetTrigger("FadeOut");
				timeStartFade = Time.time;
				isFading = true;
			}
		}

		if (isFading && Time.time - timeStartFade > totalFadeTime) {
			sceneChanger.UnloadScene("Win");
			sceneChanger.UnloadScene("Platforming Test Scene");
			dialogueTriggers[dayTracker.currentDay].manager.desktop.SetActive(true);
            FindObjectOfType<AudioManager>().Stop("bgm");
            foreach (GameObject background in GameObject.FindGameObjectsWithTag("Application"))
			{
				background.SetActive(false);
            }
            dayTracker.nextDay();
			fadeAnimator.SetTrigger("FadeIn");
			isFading = false;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (!(isWaitingDialogue || isDialogueOpen || isFading)) {
			PlayerController player = collision.attachedRigidbody.GetComponent<PlayerController>();
			if (player != null) {
				// End of level transition logic
				Debug.Log("hit the end of the level!");
				Application.targetFrameRate = -1;
				sceneChanger.LoadScene();
				timeStartEndLevel = Time.time;
				isWaitingDialogue = true;
			}
		}
	}
}
