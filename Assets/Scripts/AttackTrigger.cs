using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public AudioClip attackClip;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            FindObjectOfType<PlayerController>().PlaySound(attackClip);
            FindObjectOfType<Obstacle>().Hit();
        }
    }
}
