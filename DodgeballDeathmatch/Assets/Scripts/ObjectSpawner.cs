﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    float maxX;

    [SerializeField]
    float spawnInterval;

    public GameObject Knife;
    public GameObject Heart;

	// Use this for initialization
	void Start () 
    {
        StartSpawning();
	}

    // Update is called once per frame
    // As the time intveral decreases the number of knives spawned increases
    void Update()
    {
        int currentTime = GameObject.Find("Timer").GetComponent<Timer>().Current;

        if(currentTime > 75 )
        {
            spawnInterval = 3f;
        }
        else if (currentTime < 75 && currentTime > 50)
        {
            spawnInterval = 1f;
        }
        else if (currentTime < 50 && currentTime > 25)
        {
            spawnInterval = 0.3f;
        }
        else if (currentTime < 25)
        {
            spawnInterval = 0.1f;
        }
    }

    // Function to randomly spawn knives throughout the dodgeball court
    void SpawnKnife()
    {
        Vector3 randomKnifepos = RandomXposition();

        // Show knife on screen to interact with player
        Instantiate(Knife, randomKnifepos, transform.rotation);
    }

    // Function to randomly spawn knives throughout the dodgeball court
    void SpawnHeart()
    {
        Vector3 randomHeartpos = RandomXposition();

        // Show heart on screen to interact with player
        Instantiate(Heart, randomHeartpos, transform.rotation);
    }

    // Function to place the falling object in a random position across the boundary 
    // of the dodgeball court
    Vector3 RandomXposition()
    {
        // Statement to chose where in the knives object will fall
        float randomX = Random.Range(-maxX, maxX);
        Vector3 randomPos = new Vector3(randomX, transform.position.y, transform.position.z);

        return randomPos;
    }

    // Call routine to create delay before spawning more knives
    IEnumerator SpawnKnives()
    {
        yield return new WaitForSeconds(15f);

        while(true)
        {
            SpawnKnife();

            yield return new WaitForSeconds(spawnInterval);

        }
    }

    // Call routine to create delay before spawning a heart
    IEnumerator SpawnHearts()
    {
        yield return new WaitForSeconds(50f);

        while (true)
        {
            SpawnHeart();

            yield return new WaitForSeconds(spawnInterval*5);

        }
    }

    public void StartSpawning()
    {
        StartCoroutine("SpawnKnives");
        StartCoroutine("SpawnHearts");
    }

    public void StopSpawning()
    {
        StopCoroutine("SpawnKnives");
        StopCoroutine("SpawnHearts");
    }

}
