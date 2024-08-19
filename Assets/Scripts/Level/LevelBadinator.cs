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
		public const int BAD_MOVEMENT = 5;
		public const int NO_CHECKPOINTS = 6;
		public const int NO_GAME = 7;
	}

	// Editor accessible stuff
	public PlayerController player;
	public GameObject ground;
	// ...avoid destroying the starting checkpoint
	public GameObject startingCheckpoint;
	public GameObject checkpointParent;
	public Animator gunAnimatorRef;
	public Animator playerAnimatorRef;

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
		}
		if (badness >= LevelBadness.BAD_MOVEMENT) {

		}
		if (badness >= LevelBadness.NO_CHECKPOINTS) {
			foreach (Transform transform in checkpointParent.transform) {
				if (transform.gameObject != startingCheckpoint) {
					Destroy(transform.gameObject);
				}
			}
		}
		if (badness >= LevelBadness.NO_GAME) {

		}
	}
}
