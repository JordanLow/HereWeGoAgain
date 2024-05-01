using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 100;
	
	public void takeHit(int damage) {
		health -= damage;
	}
	
	void Update() {
		// if (health <= 0) do something I guess
	}
}
