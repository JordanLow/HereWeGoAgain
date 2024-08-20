using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 3;
	
	public void takeHit(int damage) {
		health -= damage;
	}
	
	public void takeKnockback(Quaternion angle, float distance) {
		// knockback
	}
	
	public void takeStun(float duration) {
		// duration
	}
	
	void Update() {
		if (health <= 0) Destroy(gameObject);
	}
}
