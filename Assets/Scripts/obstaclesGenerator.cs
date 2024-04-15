using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclesGenerator : MonoBehaviour
{
    public GameObject obstacles;
    public float maxX;
    public float maxY;
    public float minX;
    public float minY;
    public float TimeBetSpawn;
    private float SpawnTime;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > SpawnTime)
        {
            spawn();
            SpawnTime = Time.time + TimeBetSpawn;
        }
        
    }

    void spawn()
    {
        float x = Random.Range(minX, maxY);
        float y = Random.Range(minY,maxY);
        Instantiate(obstacles, transform.position + new Vector3(x, y, 0), transform.rotation);
    }
}
