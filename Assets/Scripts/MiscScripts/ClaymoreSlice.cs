using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaymoreSlice : MonoBehaviour
{
	PlayerCombat player;
	
	[SerializeField] int damage = 1;
	[SerializeField] float knockback = 0.5f;
	[SerializeField] float stunDuration = 1f;
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			player.hitEnemy();
			other.gameObject.GetComponent<EnemyHealth>().takeHit(damage);
			other.gameObject.GetComponent<EnemyHealth>().takeKnockback(transform.rotation, knockback);
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
