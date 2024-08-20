using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour {
	bool didReflect = false;
	public Vector3 velocity;
	public SpriteRenderer spriteRenderer;

	// Start is called before the first frame update
	void Start() {
		spriteRenderer.flipX = velocity.x < 0;
	}

	// Update is called once per frame
	void FixedUpdate() {
		didReflect = false;
		transform.position += velocity * Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D other) {
		int layer = other.gameObject.layer;
		if ((layer == 6 || layer == 8 || layer == 10) && !didReflect) {
			// Undo last move
			transform.position -= velocity * Time.deltaTime;
			velocity *= -1;
			didReflect = true;
			spriteRenderer.flipX = velocity.x < 0;
		} else if (layer == 9) {
            // Bullet collision
            FindObjectOfType<AudioManager>().Play("deathEnemy");
            Destroy(this.gameObject);
		}
	}
}
