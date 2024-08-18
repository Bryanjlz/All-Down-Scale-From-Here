using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision) {
		PlayerController player = collision.attachedRigidbody.GetComponent<PlayerController>();
		if (player != null) {
			// End of level transition logic
			Debug.Log("hit the end of the level!");
		}
	}
}
