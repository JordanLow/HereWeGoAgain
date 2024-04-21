using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerMovement : MonoBehaviour
{
	
	Vector2 moveInput;
	Vector2 mousePosition;
	[SerializeField] float moveSpeed;
	
	void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

	void OnAim(InputValue value) {
		mousePosition = value.Get<Vector2>();
	}

    void Update()
    {
		float move = moveSpeed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveInput.x * move, moveInput.y * move);
		transform.localScale = new Vector2((Mathf.Sign(mousePosition.x - Screen.width/2)) * Mathf.Abs(transform.localScale.x), transform.localScale.y);
    }
	
	
	public Vector2 GetMousePos() {
		return mousePosition;
	}
}


