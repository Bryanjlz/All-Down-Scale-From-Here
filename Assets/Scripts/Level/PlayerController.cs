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

	[SerializeField]
	bool isGrounded;
	Transform transformRef;
	Collider2D colliderRef;
	Rigidbody2D rigidbodyRef;
	[SerializeField]
	Animator playerAnimatorRef;
	[SerializeField]
	Animator gunAnimatorRef;
	[SerializeField]
	GameObject deathParticles;
	[SerializeField]
	GameObject respawnParticles;

	float uncontrolledTime = 0;
	
	bool isFacingRight = true;

	private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
		audioManager = FindObjectOfType<AudioManager>();
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
		UpdateIsGrounded();
		playerAnimatorRef.SetBool("isGrounded", isGrounded);
		gunAnimatorRef.SetBool("isGrounded", isGrounded);
		if (uncontrolledTime > 0) {
			uncontrolledTime -= Time.deltaTime;
			if (uncontrolledTime <= 0) {
				Instantiate(respawnParticles, transformRef.position, Quaternion.identity, transform);
				GetComponent<SpriteRenderer>().enabled = true;
				foreach (Transform t in transform) {
					SpriteRenderer renderer = t.GetComponent<SpriteRenderer>();
					if (renderer != null) {
						renderer.enabled = true;
					}
				}
			}
		}

		rigidbodyRef.velocity = new Vector2(0, rigidbodyRef.velocity.y);

		if (uncontrolledTime <= 0) {
			if (Input.GetKey(KeyCode.LeftArrow)) {
				rigidbodyRef.velocity = new Vector2(-moveSpeed, rigidbodyRef.velocity.y);
				if (isFacingRight) {
					FlipDirection();
				}
				isFacingRight = false;
			}

			if (Input.GetKey(KeyCode.RightArrow)) {
				rigidbodyRef.velocity = new Vector2(moveSpeed, rigidbodyRef.velocity.y);
				if (!isFacingRight) {
					FlipDirection();
				}
				isFacingRight = true;
			}

			if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded) {
                if (UnityEngine.Random.value < .5)
                {
					Debug.Log("jump1");
                    audioManager.Play("jump1");
                }
                else
				{
                    Debug.Log("jump2");
                    audioManager.Play("jump2");
                }
                rigidbodyRef.velocity = new Vector2(rigidbodyRef.velocity.x, jumpStrength);
			} else if (Input.GetKeyUp(KeyCode.UpArrow) && rigidbodyRef.velocity.y > shortHopSpeed) {
				rigidbodyRef.velocity = new Vector2(rigidbodyRef.velocity.x, shortHopSpeed);
			}
		}
		
		// Update speed for animator
		playerAnimatorRef.SetFloat("xVelocity", Mathf.Abs(rigidbodyRef.velocity.x));

		// Higher falling speed
		if (rigidbodyRef.velocity.y < 0) {
			rigidbodyRef.gravityScale = 2.0f;
		} else {
			rigidbodyRef.gravityScale = 1.0f;
		}
    }

	// Player Death
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.layer == 8) {
            audioManager.Play("death");
            rigidbodyRef.velocity = Vector2.zero;
			StartCoroutine(delayedPositionUpdate());
			Instantiate(deathParticles, transformRef.position, Quaternion.identity);
			uncontrolledTime = deathTimeout;
			GetComponent<SpriteRenderer>().enabled = false;
			foreach (Transform t in transform) {
				SpriteRenderer renderer = t.GetComponent<SpriteRenderer>();
				if (renderer != null) {
					renderer.enabled = false;
				}
			}
		}
	}

	void UpdateIsGrounded() {
		RaycastHit2D leftCast = Physics2D.Raycast(transformRef.position - new Vector3(colliderRef.bounds.extents.x, 0, 0), Vector2.down, colliderRef.bounds.extents.y + 0.1f, LayerMask.GetMask("World"));
		RaycastHit2D midCast = Physics2D.Raycast(transformRef.position, Vector2.down, colliderRef.bounds.extents.y + 0.1f, LayerMask.GetMask("World"));
		RaycastHit2D rightCast = Physics2D.Raycast(transformRef.position + new Vector3(colliderRef.bounds.extents.x, 0, 0), Vector2.down, colliderRef.bounds.extents.y + 0.1f, LayerMask.GetMask("World"));


		isGrounded = leftCast.collider != null || rightCast.collider != null || midCast.collider != null;
	}

	public void UpdateRespawnPoint(Vector2 newLocation) {
		respawnPoint = newLocation;
	}

	/// <summary>
	/// Returns 1 if facing right, -1 if facing left.
	/// Use for math based on what direction the player is facing (gun).
	/// </summary>
	public int GetFacingDirection() {
		return isFacingRight ? 1 : -1;
	}

	public void FlipDirection() {
		Vector3 scale = transformRef.localScale;
		scale.x *= -1;
		transformRef.localScale = scale;
	}

	IEnumerator delayedPositionUpdate() {
		yield return new WaitForSeconds(deathTimeout / 2);
		transform.SetPositionAndRotation(new Vector3(respawnPoint.x, respawnPoint.y, 0), Quaternion.identity);
	}
}
