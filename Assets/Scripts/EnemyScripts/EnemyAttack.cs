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
		mat.SetFloat("_FlashAmount", 0.7f);
		yield return new WaitForSeconds(0.2f);
		mat.SetFloat("_FlashAmount", 0.15f);
		yield return new WaitForSeconds(0.15f);
		mat.SetFloat("_FlashAmount", 0.7f);
		yield return new WaitForSeconds(0.15f);
		mat.SetFloat("_FlashAmount", 0.15f);
		yield return new WaitForSeconds(0.1f);
		mat.SetFloat("_FlashAmount", 0.7f);
		yield return new WaitForSeconds(0.1f);
		animator.SetTrigger("HobblerAttacking");
		mat.SetFloat("_FlashAmount", 0f);
		// Change flash colour to Yellow and then do the flashing thing for this stun duration
		mat.SetColor("_FlashColor", stunColor);
		yield return new WaitForSeconds(0.3f);
		mat.SetFloat("_FlashAmount", 0.7f);
		yield return new WaitForSeconds(0.1f);
		mat.SetFloat("_FlashAmount", 0.15f);
		yield return new WaitForSeconds(0.15f);
		mat.SetFloat("_FlashAmount", 0.7f);
		yield return new WaitForSeconds(0.2f);
		mat.SetFloat("_FlashAmount", 0.15f);
		yield return new WaitForSeconds(0.25f);
		mat.SetFloat("_FlashAmount", 0.7f);
		yield return new WaitForSeconds(0.3f);
		mat.SetFloat("_FlashAmount", 0f);
		attacking = false;
		movement.SetMovementLockout(false);
	}
}
