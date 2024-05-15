using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	
	[SerializeField] float contactDamageCooldownDuration = 0.25f;
	Material mat;
	EnemyMovement movement;
	Animator animator;
	
	bool attacking = false;
	
	float contactDamageCooldown = 0f;
    
	void Start() {
		movement = GetComponent<EnemyMovement>();
		mat = GetComponent<SpriteRenderer>().material;
		animator = GetComponent<Animator>();
	}
	
	void OnTriggerStay2D(Collider2D other) {
		if (other.tag == "Player") {
			if (contactDamageCooldown > 0) return;
			contactDamageCooldown = contactDamageCooldownDuration;
			other.gameObject.GetComponent<PlayerHealth>().takeHit(1);
		}
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			if (contactDamageCooldown > 0) return;
			contactDamageCooldown = contactDamageCooldownDuration;
			other.gameObject.GetComponent<PlayerHealth>().takeHit(1);
		}
	}

    void Update()
    {
		if (contactDamageCooldown > 0f) contactDamageCooldown -= Time.deltaTime;
		if (contactDamageCooldownDuration <= 0f) contactDamageCooldown = 0f;
		if (movement.DistanceFromPlayer() < 2) {
			if (!attacking) StartCoroutine(MakeAttack());
		}
    }
	
	
	private IEnumerator MakeAttack() {
		attacking = true;
		movement.SetMovementLockout(true);
		mat.SetFloat("_FlashAmount", 0.6f);
		// Make it flash blink multiple times
		yield return new WaitForSeconds(0.6f);
		animator.SetTrigger("HobblerAttacking");
		mat.SetFloat("_FlashAmount", 0f);;
		yield return new WaitForSeconds(1f);
		attacking = false;
		movement.SetMovementLockout(false);
	}
}
