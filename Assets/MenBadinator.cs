using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenBadinator : MonoBehaviour {
	[SerializeField] private GameObject goodTiles;
	[SerializeField] private GameObject badTiles;
	[SerializeField] private GameObject background;
	void Start()
	{
		int badness = GameObject.FindGameObjectWithTag("DayManager").GetComponent<TrackDay>().currentDay;
		if (badness >= 4) {
			goodTiles.SetActive(false);
			badTiles.SetActive(true);
			background.SetActive(false);
		}
	}
}
