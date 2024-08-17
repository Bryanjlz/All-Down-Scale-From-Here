using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
	bool didReflect = false;
	public Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		didReflect = false;
		transform.position += velocity * Time.deltaTime;
    }

	void OnTriggerEnter2D(Collider2D other) {
		int layer = other.gameObject.layer;
		if (layer == 6 || layer == 8 && !didReflect) {
			// Undo last move
			transform.position -= velocity * Time.deltaTime;
			velocity *= -1;
			didReflect = true;
		} else if (layer == 9) {
			Destroy(this.gameObject);
		}
	}
}
