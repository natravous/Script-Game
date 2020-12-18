using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sut : MonoBehaviour
{
    public GameObject peluru;

    public Transform player;

    private float timeBetweenShot;
    public float startTimeBetweenShot;
    public float stopDistance;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBetweenShot = startTimeBetweenShot;
    }

    // Update is called once per frame
    void Update()
    {
       

        if(timeBetweenShot <= 0 && Vector2.Distance(transform.position, player.position) < stopDistance)
        {
            Instantiate(peluru, transform.position, Quaternion.identity);

            timeBetweenShot = startTimeBetweenShot;
        }
        else
        {
            timeBetweenShot -= Time.deltaTime;
        }

    }

   
}
