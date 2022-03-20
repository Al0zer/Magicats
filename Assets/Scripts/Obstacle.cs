using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int hitPoints = 50;
    private GameObject player;

    public ParticleSystem attackSparkle;
    public ParticleSystem hitSparkle;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("BoughtAttack") != 0)
        {
            hitPoints *= 2;
        }

        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }


    public void Hit()
    {
        FindObjectOfType<ScoreManager>().AddScore(hitPoints);
        Instantiate(attackSparkle, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }

        if (collision.tag == "Player")
        {
            Instantiate(hitSparkle, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
