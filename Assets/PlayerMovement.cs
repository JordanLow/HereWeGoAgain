using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using System;

public class PlayerMovement : MonoBehaviour
{
	
	Vector2 moveInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }
	
	void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
		//Debug.Log(moveInput.x.ToString());
    }

    // Update is called once per frame
    void Update()
    {
		float move = 20f;
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveInput.x * move, moveInput.y * move);
    }
}
