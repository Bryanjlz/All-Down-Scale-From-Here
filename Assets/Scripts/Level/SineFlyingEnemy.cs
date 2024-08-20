using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class SineFlyingEnemy : MonoBehaviour
{
	public float magnitude;
	public float period;
	public float offset;
	// Make this (0, 1, 0) for vertical sine movement
	public Vector3 sineAxis;
	public Vector3 basePoint;
	public bool useStartingPosition;
	public GameObject deathParticles;

	private float internalTimer = 0f;

	// Start is called before the first frame update
	void Start()
    {
        if (basePoint == null || useStartingPosition) {
			basePoint = transform.position;
		}
    }

    // Update is called once per frame
    void Update()
    {
		internalTimer += Time.deltaTime;
		transform.position = basePoint + sineAxis * Mathf.Sin(offset + 2 * Mathf.PI * internalTimer / period) * magnitude;
    }


	void OnTriggerEnter2D(Collider2D other) {
		int layer = other.gameObject.layer;
		if (layer == 9) {
			// Bullet collision
			Destroy(this.gameObject);
			Instantiate(deathParticles, transform.position, Quaternion.identity);
		}
	}
}
