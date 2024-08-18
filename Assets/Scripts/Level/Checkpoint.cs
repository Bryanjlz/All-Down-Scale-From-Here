using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D other) {
		// If player
		PlayerController player = other.GetComponent<PlayerController>();
		if (player != null) {
			player.UpdateRespawnPoint(transform.position);
		}
	}
}
