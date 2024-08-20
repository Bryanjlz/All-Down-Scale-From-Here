using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
	public GameObject flagParticles;

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
			if (!player.respawnPoint.Equals(transform.position)) {
				if (GetComponent<SpriteRenderer>()?.enabled == true) {
					FindObjectOfType<AudioManager>().Play("flagCollect");
					Instantiate(flagParticles, transform);
					GetComponent<Animator>().SetTrigger("collect");
				}
				player.UpdateRespawnPoint(transform.position);
			}
		}
	}
}
