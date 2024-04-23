using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaymoreSlice : MonoBehaviour
{
	PlayerCombat player;
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			player.hitEnemy();
			other.gameObject.GetComponent<EnemyHealth>().takeHit(1);
		}			
	}
	
    public void FinishAnim() {
		Destroy(gameObject);
	}
	
	public void setPlayer(PlayerCombat origin) {
		player = origin;
	}
}
