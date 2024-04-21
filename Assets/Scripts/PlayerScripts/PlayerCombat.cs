using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
	[SerializeField] float cooldownDuration = 0.2f;
	[SerializeField] GameObject claymoreSlice;
	
	[SerializeField] Transform indicatorOrigin;
	
	float cooldown = 0f;
	void OnAttack(InputValue value) {
		if (cooldown > 0) return;
		cooldown = cooldownDuration;
		GameObject slice = Instantiate(claymoreSlice, indicatorOrigin.position, indicatorOrigin.rotation);
		Animator animator = slice.GetComponent<Animator>();
		slice.GetComponent<ClaymoreSlice>().setPlayer(this);
		animator.Play("Claymore Slice");
	}
	
	void OnSpecial(InputValue value) {
		
	}

    void Update()
    {
        if (cooldown > 0) cooldown -= Time.deltaTime;
    }
}
