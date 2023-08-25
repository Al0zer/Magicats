using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool attacking = false;

    private float attackTimer = 0;
    private float coolDown = 0.2f;

    public Collider2D attackTrigger;

    Animator animator;

    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    void Update()
    {
        //windows controls, disabled for mobile
        //if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("d") && !attacking)
        //{
        //    this.Attack();
        //}

        if (attacking)
        {
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }

            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }

    }

    public void Attack()
    {
        attacking = true;
        attackTimer = coolDown;

        attackTrigger.enabled = true;

        animator.SetTrigger("Attack");
    }
}
