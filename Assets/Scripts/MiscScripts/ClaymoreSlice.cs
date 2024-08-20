using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaymoreSlice : MonoBehaviour
{
	PlayerCombat player;
	
	[SerializeField] int damage = 1;
	[SerializeField] float knockbackStrength = 2f;
	[SerializeField] float stunDuration = 1f;
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			player.hitEnemy();
			other.gameObject.GetComponent<EnemyHealth>().takeHit(damage);
			other.gameObject.GetComponent<EnemyHealth>().takeKnockback(transform.rotation, knockbackStrength);
			other.gameObject.GetComponent<EnemyHealth>().takeStun(stunDuration);
		}			
	}

    public void FinishAnim() {
		Destroy(gameObject);
	}
	
	public void setPlayer(PlayerCombat origin) {
		player = origin;
	}
}
