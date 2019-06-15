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
        else if (vertical != 0 || horizontal != 0)
        {
            animator.SetBool("Walk", true);
		}

        
        if (Input.GetKeyDown (KeyCode.F) && GameObject.FindGameObjectWithTag("Player").GetComponent<playerstat>().curMP > GameObject.FindGameObjectWithTag("Player").GetComponent<playerstat>().minEnerjyForHit && !IsAnimationPlaying("Attack")) {

            GameObject.FindGameObjectWithTag("Player").GetComponent<playerstat>().curMP -= GameObject.FindGameObjectWithTag("Player").GetComponent<playerstat>().minEnerjyForHit;

            animator.SetBool ("Walk", false);
			animator.SetTrigger ("Attack");
            triggerDamage.SetActive(true);
		}

        if (Input.GetKeyDown(KeyCode.Tab) && hpBottle_player.hp > 0)
        {
           // animator.SetBool("Walk", false);
            animator.SetTrigger("HP_bottle");            
        }
        
    }

    // для проверки окончания анимации
    public bool IsAnimationPlaying(string animationName)
    {
        // берем информацию о состоянии
        var animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        // смотрим, есть ли в нем имя какой-то анимации, то возвращаем true
        if (animatorStateInfo.IsName(animationName))
            return true;

        return false;
    }
}
