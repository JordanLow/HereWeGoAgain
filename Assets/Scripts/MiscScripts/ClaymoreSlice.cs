using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaymoreSlice : MonoBehaviour
{
	PlayerCombat player;
	
	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("collided");
	}
	
    public void FinishAnim() {
		Destroy(gameObject);
	}
	
	public void setPlayer(PlayerCombat origin) {
		player = origin;
	}
}
