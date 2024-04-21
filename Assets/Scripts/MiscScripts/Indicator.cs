using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    
	[SerializeField] GameObject player;
    void Update()
    {
		transform.position = player.transform.position;
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint(player.GetComponent<PlayerMovement>().GetMousePos());
		Vector2 direction = mousePosition - new Vector2(transform.position.x, transform.position.y);
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
