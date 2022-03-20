using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    //public GameObject obstacle;

    public float maxX;
    public float minX;
    public float maxY;
    public float minY;

    public float timeBetweenSpawn;
    private float spawnTime;

    private int rand;
    public GameObject[] sprites;


    // Update is called once per frame
    void Update()
    {
        //timeBetweenSpawn = Random.Range(1f, 4f);

        if(Time.time > spawnTime)
        {
            SpawnObjects();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void SpawnObjects()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        rand = Random.Range(0, sprites.Length);

        Instantiate(sprites[rand], transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }

    public void IncreaseSpawn()
    {
        if(timeBetweenSpawn != 1)
        {
            timeBetweenSpawn -= 0.5f;
        }
    }
}
