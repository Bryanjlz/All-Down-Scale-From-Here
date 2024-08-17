using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	// Editor variables
	public float jumpStrength;
	public float moveSpeed;


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
    }

    // Update is called once per frame
    void Update()
    {
		updateIsGrounded();

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


	void updateIsGrounded() {

		isGrounded = Physics2D.Raycast(transformRef.position, Vector2.down, collider.bounds.extents.y + 0.1f).collider != null;
	}
}
