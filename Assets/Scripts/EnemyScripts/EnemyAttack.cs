using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	
	[SerializeField] float contactDamageCooldownDuration = 0.25f;
	[SerializeField] Color attackColor;
	[SerializeField] Color stunColor;
	Material mat;
	EnemyMovement movement;
	Animator animator;
	
	float[] windUpFlashArray = { 0.2f, 0.15f, 0.15f, 0.1f, 0.1f };
	float[] coolDownFlashArray = { 0.1f, 0.15f, 0.2f, 0.25f, 0.3f };
	
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
		mat.SetColor("_FlashColor", attackColor);
		mat.SetFloat("_FlashAmount", 0.7f); // Begin the attack flashing

		float flashAmount = 0.15f;
		foreach (float interval in windUpFlashArray) {
			yield return new WaitForSeconds(interval);
			mat.SetFloat("_FlashAmount", flashAmount);
			flashAmount = flashAmount == 0.15f ? 0.7f : 0.15f;
		}
		
		animator.SetTrigger("HobblerAttacking");
		mat.SetFloat("_FlashAmount", 0f);

		mat.SetColor("_FlashColor", stunColor);
		yield return new WaitForSeconds(0.3f); // Duration of the attack
		
		mat.SetFloat("_FlashAmount", 0.7f); // Begin the stun flashing
		flashAmount = 0.15f;
		foreach (float interval in coolDownFlashArray) {
			yield return new WaitForSeconds(interval);
			mat.SetFloat("_FlashAmount", flashAmount);
			flashAmount = flashAmount == 0.15f ? 0.7f : 0.15f;
		}

		mat.SetFloat("_FlashAmount", 0f);
		attacking = false;
		movement.SetMovementLockout(false);
	}
}
