using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

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
    public bool badMovement = false;
    public float counter = 0;

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
        if (badMovement)
        {
            counter += Time.deltaTime;
            internalTimer += Time.deltaTime;
            if (counter > 0.1f)
            {
                transform.position = basePoint + sineAxis * Mathf.Sin(offset + 2 * Mathf.PI * internalTimer / period) * magnitude;
                counter = 0;
            }
        } else
		{
            internalTimer += Time.deltaTime;
            transform.position = basePoint + sineAxis * Mathf.Sin(offset + 2 * Mathf.PI * internalTimer / period) * magnitude;
        }
        
    }


	void OnTriggerEnter2D(Collider2D other) {
		int layer = other.gameObject.layer;
		if (layer == 9) {
			// Bullet collision
			FindObjectOfType<AudioManager>().Play("deathEnemy");
			Instantiate(deathParticles, transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
	}
}
