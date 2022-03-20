using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public int health;
    public int numOfHearts = 3;

    public Image[] heart;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public AudioClip hurtClip;

    private GameOver gameOver;

    Animator animator;

    void Start()
    {
        if(PlayerPrefs.GetInt("BoughtHealth") != 0)
        {
            numOfHearts = 5;
        }

        health = numOfHearts;
        animator = gameObject.GetComponent<Animator>();
        gameOver = FindObjectOfType<GameOver>();
    }

    void Update()
    {
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }

        for(int i = 0; i < heart.Length; i++)
        {
            if(i < health)
            {
                heart[i].sprite = fullHeart;
            }

            else
            {
                heart[i].sprite = emptyHeart;
            }

            if(i < numOfHearts)
            {
                heart[i].enabled = true;
            }

            else
            {
                heart[i].enabled = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            health -= 1;
            animator.SetTrigger("Hurt");

            FindObjectOfType<PlayerController>().PlaySound(hurtClip);
        }

        if (health == 0)
        {
            gameOver.isDead = true;
            health = numOfHearts;
        }

    }

}
