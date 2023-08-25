using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxJumps = 2;
    public float playerSpeed;

    private int jumps;

    public float jumpHeight = 4;
    private Rigidbody2D rb;
    public bool grounded = false;

    public AudioClip hurtClip;


    Animator animator;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumps = maxJumps;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //when jump button is pressed
        //windows controls, disabled for mobile
        //if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        //{
        //    this.Jump();
        //}
    }

    public void Jump()
    {
        animator.SetBool("Jump", true);

        if (jumps > 0)
        {
            rb.AddForce(new Vector2(0, jumpHeight) * playerSpeed, ForceMode2D.Impulse);
            grounded = false;
            jumps = jumps - 1;
        }
        if(jumps == 0)
        {
            return;
        }

        PlaySound(hurtClip);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            jumps = maxJumps;
            grounded = true;
            animator.SetBool("Jump", false);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
