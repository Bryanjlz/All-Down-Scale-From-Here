using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBadinator : MonoBehaviour
{

	public static class LevelBadness {
		public const int REGULAR_GAME = 0;
		public const int NO_BULLETS = 1;
		public const int NO_GROUND = 2;
		public const int NO_GUN = 3;
		public const int BAD_GRAPHICS = 4;
		public const int BAD_FRAMERATE = 5;
		public const int NO_CHECKPOINTS = 6;
		public const int NO_GAME = 7;
	}

	// Editor accessible stuff
	public PlayerController player;
	public GameObject ground;
	// ...avoid destroying the starting checkpoint
	public GameObject startingCheckpoint;
	// ...and the ending one, which is visual
	public GameObject endingCheckpoint;
	public GameObject checkpointParent;
	public GameObject gameOverPrefab;

	// graphic downgrade refs
	public Animator gunAnimatorRef;
	public Animator playerAnimatorRef;
	public GameObject goodTiles;
	public GameObject badTiles;
	public GameObject enemiesParent;
	public GameObject background;

	public int badness;

    // Start is called before the first frame update
    void Start()
    {
        badness = GameObject.FindGameObjectWithTag("DayManager").GetComponent<TrackDay>().currentDay;
		setLevelBadness(badness);
    }

	public void setLevelBadness(int badness) {
		if (badness >= LevelBadness.NO_BULLETS) {
			player.GetComponent<GunController>().RemoveBullets();
		}
		if (badness >= LevelBadness.NO_GROUND) {
			Destroy(ground);
		}
		if (badness >= LevelBadness.NO_GUN) {
			gunAnimatorRef.SetBool("hasGun", false);
			Destroy(player.GetComponent<GunController>());
		}
		if (badness >= LevelBadness.BAD_GRAPHICS) {
			gunAnimatorRef.SetBool("isBad", true);
			playerAnimatorRef.SetBool("isBad", true);
			foreach (Animator enemyAnimator in enemiesParent.GetComponentsInChildren<Animator>()) {
				enemyAnimator.SetBool("isBad", true);
			}
			goodTiles.SetActive(false);
			badTiles.SetActive(true);
			foreach (Animator flagAnimator in checkpointParent.GetComponentsInChildren<Animator>()) {
				if (flagAnimator.gameObject != startingCheckpoint) {
					flagAnimator.SetBool("isBad", true);
				}
			}
			background.SetActive(false);
		}
		if (badness >= LevelBadness.BAD_FRAMERATE) {
			Application.targetFrameRate = 15;
		}
		if (badness >= LevelBadness.NO_CHECKPOINTS) {
			foreach (Transform transform in checkpointParent.transform) {
				if (transform.gameObject != startingCheckpoint && transform.gameObject != endingCheckpoint) {
					Destroy(transform.gameObject);
				}
			}
		}
		if (badness >= LevelBadness.NO_GAME) {
			Instantiate(gameOverPrefab);
			FindObjectOfType<AudioManager>().Play("loadingDone");
			Destroy(player);
		}
	}
}
