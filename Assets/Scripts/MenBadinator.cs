using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MenBadinator : MonoBehaviour {
	[SerializeField] private GameObject goodTiles;
	[SerializeField] private GameObject badTiles;
	[SerializeField] private GameObject background;
    [SerializeField] private GameObject animator;

    void Start() {
	    int badness = GameObject.FindGameObjectWithTag("DayManager").GetComponent<TrackDay>().currentDay;
	    if (badness >= 4) {
		    goodTiles.SetActive(false);
		    badTiles.SetActive(true);
		    background.SetActive(false);
	    }

	    if (badness >= 7) {
		    background.GetComponent<Tilemap>().color = Color.red;
		    background.SetActive(true);
		    animator.GetComponent<Animator>().enabled = false;
	    }
    }
}
