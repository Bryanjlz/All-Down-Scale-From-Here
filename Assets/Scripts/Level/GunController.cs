using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
	// Editor accessible variables
	public float cooldown;
	public float bulletSpeed;

	public Bullet bulletPrefab;
	public PistolWhip pistolWhipPrefab;
	public GameObject gunVisualRef;

	private float internalCooldown;
	private PlayerController player;
	private bool isShootingAllowed = true;
	
	[SerializeField]
	Animator animatorRef;

    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        player = GetComponent<PlayerController>();
		if (player == null) {
			Debug.LogError("Gun should be instantiated on the same object as the player character!");
		}
    }

    // Update is called once per frame
    void Update() {
		if (internalCooldown > 0) {
			internalCooldown -= Time.deltaTime;
		}

		if (Input.GetKeyDown(KeyCode.Space) && internalCooldown <= 0) {
			internalCooldown = cooldown;
			Vector3 position = transform.position;
			if (isShootingAllowed) {
                if (UnityEngine.Random.value < .5)
                {
                    audioManager.Play("shoot1");
                }
                else
                {
                    audioManager.Play("shoot2");
                }
                animatorRef.SetTrigger("shoot");
				position.y -= 0.15f;
				position.x += 0.5f * player.GetFacingDirection();
				GameObject go = Instantiate(bulletPrefab.gameObject, position, Quaternion.identity);
				Bullet bullet = go.GetComponent<Bullet>();
				bullet.SetVelocity(new Vector3(bulletSpeed * player.GetFacingDirection(), 0, 0));
			} else {
                // Pistol whip
                audioManager.Play("whip");
                animatorRef.SetTrigger("whip");
				position.y -= 0.15f;
				position.x += .7f * player.GetFacingDirection();
				// Keep pistol whip attached to player
				GameObject go = Instantiate(pistolWhipPrefab.gameObject, position, Quaternion.identity, transform);
				PistolWhip attack = go.GetComponent<PistolWhip>();
			}
		}
	}

	public void RemoveBullets() {
		isShootingAllowed = false;
	}
}
