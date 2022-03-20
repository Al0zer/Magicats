using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public int pointsToGive = 50;
    public ParticleSystem starSparkle;

    public AudioClip starClip;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            FindObjectOfType<ScoreManager>().AddScore(pointsToGive);
            FindObjectOfType<CurrencyManager>().AddStars(1);

            FindObjectOfType<PlayerController>().PlaySound(starClip);

            Instantiate(starSparkle, transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }

        if (collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }
    }
}
