using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	// Editor variables
	public float jumpStrength;
	public float moveSpeed;
	public Vector2 respawnPoint;

	bool isGrounded;
	Transform transformRef;
	Collider2D collider;
	Rigidbody2D rigidbodyRef;

    // Start is called before the first frame update
    void Start()
    {
		transformRef = transform;
		collider = GetComponent<Collider2D>();
		rigidbodyRef = GetComponent<Rigidbody2D>();
		if (respawnPoint == null) {
			respawnPoint = new Vector2(0, 0);
		}
    }

    // Update is called once per frame
    void Update()
    {
		updateIsGrounded();

		rigidbodyRef.velocity = new Vector2(0, rigidbodyRef.velocity.y);

		if (Input.GetKey(KeyCode.LeftArrow)) {
			rigidbodyRef.velocity = new Vector2(-moveSpeed, rigidbodyRef.velocity.y);
		}

		if (Input.GetKey(KeyCode.RightArrow)) {
			rigidbodyRef.velocity = new Vector2(moveSpeed, rigidbodyRef.velocity.y);
		}

		if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
			rigidbodyRef.AddForce(new Vector2(0, jumpStrength));
		}
    }

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.layer == 8) {
			rigidbodyRef.velocity = Vector2.zero;
			transform.SetPositionAndRotation(new Vector3(respawnPoint.x, respawnPoint.y, 0), Quaternion.identity);
		}
	}

	void updateIsGrounded() {
		isGrounded = Physics2D.Raycast(transformRef.position, Vector2.down, collider.bounds.extents.y + 0.1f).collider != null;
	}

	public void updateRespawnPoint(Vector2 newLocation) {
		respawnPoint = newLocation;
	}
}
