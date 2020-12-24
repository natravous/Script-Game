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
        rand = Random.Range(1, 5);
    }
    // Start is called before the first frame update
    void Start()
    {
        laser.GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {

        if (timeBetweenSpawn <= 0)
        {
            Instantiate(laser, transform.position, Quaternion.identity);
            timeBetweenSpawn = startTimeBetweenSpawn;

        }
        else
        {
            timeBetweenSpawn -= Time.deltaTime;
        }

    }


}
