using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerMovement : MonoBehaviour
{
	
	Animator animator;
	AudioSource audioS;
	Vector2 moveInput;
	Vector2 mousePosition;
	float thrusting = 0f;
	[SerializeField] float moveSpeed;
	
	void Start() {
		animator = GetComponent<Animator>();
		audioS = GetComponent<AudioSource>();
	}
	
	void OnMove(InputValue value)
    {
        if (thrusting > 0f) return;
		animator.SetBool("Moving", true);
		moveInput = value.Get<Vector2>();
    }

	void OnAim(InputValue value) {
		mousePosition = value.Get<Vector2>();
	}

    void Update()
    {
		float move = moveSpeed;
		if (thrusting > 0f) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveInput.x * move, moveInput.y * move);
			thrusting -= Time.deltaTime;
			if (thrusting <= 0f) thrusting = 0f;
			return;
		}
		if (moveInput.magnitude == 0) {
			animator.SetBool("Moving", false);
		}
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveInput.x * move, moveInput.y * move);
		transform.localScale = new Vector2((Mathf.Sign(mousePosition.x - Screen.width/2)) * Mathf.Abs(transform.localScale.x), transform.localScale.y);
    }
	
	
	public void Thrust(Quaternion rotation) {
		thrusting = 2f;
		animator.SetBool("Moving", false);
		Vector3 forwardDirection = rotation * Vector3.forward;
        moveInput = new Vector2(forwardDirection.x, forwardDirection.y);
        moveInput.Normalize();
		Debug.Log("Rotation direction as Vector3: " + forwardDirection);
		Debug.Log("Rotation direction as Vector2: " + moveInput);
		
	}
	
	public void FootstepLand() {
		// Play the footstep sound effect via AnimationEvents to ensure sound-animation sync
		audioS.Play();
	}
	
	public Vector2 GetMousePos() {
		return mousePosition;
	}
}


