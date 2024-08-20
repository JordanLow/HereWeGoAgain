using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
	Transform playerLocation;
	Vector3 direction;
	[SerializeField] float moveSpeed = 2f;
	[SerializeField] GameObject stunIcon;
	float gettingKnockedBack = 0f; // Float -> Over how long the knockback takes place
	float stunned = 0f; // Float -> Duration of stun
	bool lockout = false;
	bool attacking = false;
	Shader shader;
	
	GameObject stunIconInst;

	void Start() {
		 playerLocation = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
    void Update()
    {
		if (gettingKnockedBack > 0f) {
			gettingKnockedBack -= Time.deltaTime;
			if (gettingKnockedBack <= 0f) {
				gettingKnockedBack = 0f;
				GetComponent<Rigidbody2D>().velocity = Vector3.zero;
			}
		}
		if (stunned > 0f) {
			stunned -= Time.deltaTime;
			if (stunned <= 0f) {
				stunned = 0f;
				Destroy(stunIconInst);
				stunIconInst = null;
			}
			return;
		}
		if (attacking) GetComponent<Rigidbody2D>().velocity = direction * 4f;
		if (lockout) return;
        direction = (playerLocation.position - transform.position).normalized;
		GetComponent<Rigidbody2D>().velocity = direction * moveSpeed;
    }
	
	public float DistanceFromPlayer() {
		return Vector3.Distance(playerLocation.position, transform.position);
	}
	
	public void SetMovementLockout(bool state) {
		GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		direction = (playerLocation.position - transform.position).normalized;
		// Toggle Idle/Movement animation
		lockout = state;
	}
	
	public void StartAttack() {
		attacking = true;
	}
	
	public void EndAttack() {
		GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		attacking = false;
	}
	
	public void getPushed(Vector3 push, float strength) {
		gettingKnockedBack = 0.15f;
		GetComponent<Rigidbody2D>().velocity = push * strength;
	}
	
	public void getStunned(float duration) {
		stunned = duration;
		GetComponent<EnemyAttack>().getStunned();
		attacking = false;
		lockout = false;
		if (!stunIconInst) {
			Vector3 topCornerPosition = new Vector3(GetComponent<SpriteRenderer>().bounds.min.x, GetComponent<SpriteRenderer>().bounds.max.y, GetComponent<SpriteRenderer>().bounds.center.z);
			stunIconInst = Instantiate(stunIcon, topCornerPosition, Quaternion.identity);
			stunIconInst.transform.parent = transform;
		}
	}
	
	public bool isStunned() {
		return stunned > 0f;
	}
}
