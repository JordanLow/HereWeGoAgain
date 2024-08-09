using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
	[SerializeField] float cooldownDuration = 0.2f;
	[SerializeField] GameObject claymoreSlice;
	[SerializeField] GameObject specialClaymore;
	
	[SerializeField] Transform indicatorOrigin;
	
	[SerializeField] int resource = 0;
	[SerializeField] Slider resourceSlider;
	
	float cooldown = 0f;
	
	void Start() {
		resourceSlider.maxValue = 10;
		resourceSlider.value = resource;
	}
	
	void OnAttack(InputValue value) {
		if (cooldown > 0) return;
		cooldown = cooldownDuration;
		GameObject slice = Instantiate(claymoreSlice, indicatorOrigin.position, indicatorOrigin.rotation);
		Animator animator = slice.GetComponent<Animator>();
		slice.GetComponent<ClaymoreSlice>().setPlayer(this);
		animator.Play("Claymore Slice");
	}
	
	void OnSpecial(InputValue value) {
		if (resource < 10) return;
		resource -= 10;
		resourceSlider.value = resource;
		cooldown = 0.6f;
		GameObject thrust = Instantiate(specialClaymore, indicatorOrigin.position, indicatorOrigin.rotation);
		thrust.transform.parent = transform;
		Animator animator = thrust.GetComponent<Animator>();
		thrust.GetComponent<ClaymoreThrust>().setPlayer(this);
		animator.Play("Claymore Thrust");
		GetComponent<PlayerMovement>().Thrust(indicatorOrigin.rotation);
	}

    void Update()
    {
        if (cooldown > 0) cooldown -= Time.deltaTime;
    }
	
	public void hitEnemy() {
		if (resource < 10) {
			resource++;
			resourceSlider.value = resource;
		}
	}
}
