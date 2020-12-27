using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour
{
    public float startTimeBetweenSpawn;

    private float timeBetweenSpawn;

    int rand;

    public GameObject laser;


    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        laser.GetComponent<GameMaster>();
        rand = Random.Range(3, 6);
        Debug.Log(rand);
    }

    // Update is called once per frame
    void Update()
    {

        if (timeBetweenSpawn <= 0)
        {
            //Try to only use random time
            //They still spawn at the same time first, then they spawn in rand time
            Instantiate(laser, transform.position, Quaternion.identity);
            timeBetweenSpawn = rand;//startTimeBetweenSpawn * (rand/10.0f);

        }
        else
        {
            timeBetweenSpawn -= Time.deltaTime;
        }
        

    }


}
