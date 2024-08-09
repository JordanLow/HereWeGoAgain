using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaymoreThrust : MonoBehaviour
{
    PlayerCombat player;
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			other.gameObject.GetComponent<EnemyHealth>().takeHit(3);
		}			
	}
	
    public void FinishAnim() {
		Destroy(gameObject);
	}
	
	public void setPlayer(PlayerCombat origin) {
		player = origin;
	}
}
