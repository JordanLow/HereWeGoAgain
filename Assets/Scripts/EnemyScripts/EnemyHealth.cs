using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 3;
	
	public void takeHit(int damage) {
		health -= damage;
	}
	
	void Update() {
		if (health <= 0) Destroy(gameObject);
	}
}
