using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHero : MonoBehaviour {
    public GameObject triggerDamage;
    Animator animator;

    float vertical;
    float horizontal;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
		
		if (vertical == 0 && horizontal == 0) 
		{
            animator.SetBool("Walk", false);
		}
        else if (vertical >= 0.1f || vertical <= -0.1f || horizontal >= 0.1f || horizontal <= -0.1f)
        {
            animator.SetBool("Walk", true);
		}

		if (Input.GetKeyDown (KeyCode.F)) {
			animator.SetBool ("Walk", false);
			animator.SetTrigger ("Attack");
            triggerDamage.SetActive(true);
		}
		
    }
}
