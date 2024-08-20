using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField] Slider healthSlider;
	public int maxHealth = 30;
    public int health = 30;
	
	private bool invuln = false;
	
	public void takeHit(int damage) {
		if (invuln) return;
		health -= damage;
		healthSlider.value = health;
	}

	void Start(){
		healthSlider.maxValue = health;
	}	
	void Update() {
		if (health <= 0) {Die();}
	}

	private void Die(){
		Debug.Log("Death");
	}
	
	public void setInvuln(bool inv) {
		invuln = inv;
	}
}
