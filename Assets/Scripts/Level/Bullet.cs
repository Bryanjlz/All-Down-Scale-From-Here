using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	Vector3 velocity;
	

    // Update is called once per frame
    void Update()
    {
		transform.Translate(velocity * Time.deltaTime);
    }

	private void OnTriggerEnter2D(Collider2D collision) {
		DestroyOnHit(collision.gameObject);
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		DestroyOnHit(collision.otherCollider.gameObject);
	}

	private void DestroyOnHit(GameObject other) {
		int layer = other.layer;
		switch (layer) {
			// World
			case 6: {
				Destroy(this.gameObject);
				break;
			}
			// Enemy
			case 8: {
				// TODO: Kill the enemy
				Destroy(this.gameObject);
				break;
			}
			default:
				return;
		}
	}

	public void SetVelocity(Vector3 vel) {
		velocity = vel;
	}
}
