using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	// Editor variables
	public float jumpStrength;
	public float shortHopSpeed;
	public float moveSpeed;
	public Vector2 respawnPoint;
	public float deathTimeout = 0.5f;

	bool isGrounded;
	Transform transformRef;
	Collider2D colliderRef;
	Rigidbody2D rigidbodyRef;
	float uncontrolledTime = 0;

	bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
		transformRef = transform;
		colliderRef = GetComponent<Collider2D>();
		rigidbodyRef = GetComponent<Rigidbody2D>();
		if (respawnPoint == null) {
			respawnPoint = new Vector2(0, 0);
		}
    }

    // Update is called once per frame
    void Update()
    {
		updateIsGrounded();
		if (uncontrolledTime > 0) {
			uncontrolledTime -= Time.deltaTime;
			if (uncontrolledTime <= 0) {
				GetComponent<SpriteRenderer>().enabled = true;
			}
		}


		rigidbodyRef.velocity = new Vector2(0, rigidbodyRef.velocity.y);

		if (uncontrolledTime <= 0) {
			if (Input.GetKey(KeyCode.LeftArrow)) {
				rigidbodyRef.velocity = new Vector2(-moveSpeed, rigidbodyRef.velocity.y);
				isFacingRight = false;
			}

			if (Input.GetKey(KeyCode.RightArrow)) {
				rigidbodyRef.velocity = new Vector2(moveSpeed, rigidbodyRef.velocity.y);
				isFacingRight = true;
			}

			if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded) {
				rigidbodyRef.velocity = new Vector2(rigidbodyRef.velocity.x, jumpStrength);
			} else if (Input.GetKeyUp(KeyCode.UpArrow) && rigidbodyRef.velocity.y > shortHopSpeed) {
				rigidbodyRef.velocity = new Vector2(rigidbodyRef.velocity.x, shortHopSpeed);
			}
		}

		// Higher falling speed
		if (rigidbodyRef.velocity.y < 0) {
			rigidbodyRef.gravityScale = 2.0f;
		} else {
			rigidbodyRef.gravityScale = 1.0f;
		}
    }

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.layer == 8) {
			rigidbodyRef.velocity = Vector2.zero;
			transform.SetPositionAndRotation(new Vector3(respawnPoint.x, respawnPoint.y, 0), Quaternion.identity);
			uncontrolledTime = deathTimeout;
			GetComponent<SpriteRenderer>().enabled = false;
		}
	}

	void updateIsGrounded() {
		RaycastHit2D leftCast = Physics2D.Raycast(transformRef.position - new Vector3(colliderRef.bounds.extents.x, 0, 0), Vector2.down, colliderRef.bounds.extents.y + 0.1f);
		RaycastHit2D midCast = Physics2D.Raycast(transformRef.position, Vector2.down, colliderRef.bounds.extents.y + 0.1f);
		RaycastHit2D rightCast = Physics2D.Raycast(transformRef.position + new Vector3(colliderRef.bounds.extents.x, 0, 0), Vector2.down, colliderRef.bounds.extents.y + 0.1f);


		isGrounded = leftCast.collider != null || rightCast.collider != null || midCast.collider != null;
	}

	public void updateRespawnPoint(Vector2 newLocation) {
		respawnPoint = newLocation;
	}

	/// <summary>
	/// Returns 1 if facing right, -1 if facing left.
	/// Use for math based on what direction the player is facing (gun).
	/// </summary>
	public int getFacingDirection() {
		return isFacingRight ? 1 : -1;
	}
}
