using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
	Transform playerLocation;
	Vector3 direction;
	[SerializeField] float moveSpeed = 2f;
	bool lockout = false;
	Shader shader;

	void Start() {
		 playerLocation = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
    void Update()
    {
		if (lockout) return;
        direction = (playerLocation.position - transform.position).normalized;
		GetComponent<Rigidbody2D>().velocity = direction * moveSpeed;
    }
	
	public float DistanceFromPlayer() {
		return Vector3.Distance(playerLocation.position, transform.position);
	}
	
	public void SetMovementLockout(bool state) {
		GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		// Toggle Idle/Movement animation
		lockout = state;
	}
}
