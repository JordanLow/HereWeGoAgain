using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
	[SerializeField] float cooldownDuration = 0.2f;
	[SerializeField] GameObject claymoreSlice;
	[SerializeField] GameObject specialClaymore;
	
	[SerializeField] Transform indicatorOrigin;
	
	[SerializeField] int resource = 0;
	
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
		//if (resource < 10) return;
		/* cooldown = cooldownDuration;
		GameObject thrust = Instantiate(specialClaymore, indicatorOrigin.position, indicatorOrigin.rotation);
		Animator animator = slice.GetComponent<Animator>();
		slice.GetComponent<ClaymoreThrust>().setPlayer(this);
		animator.Play("Claymore Thrust"); */
		GetComponent<PlayerMovement>().Thrust(indicatorOrigin.rotation);
	}

    void Update()
    {
        if (cooldown > 0) cooldown -= Time.deltaTime;
    }
	
	public void hitEnemy() {
		resource++;
	}
}
