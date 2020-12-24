using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float startTimeBetweenSpawn;

    private float timeBetweenSpawn;

    public GameObject projectile;

    
    // Start is called before the first frame update
    void Start()
    {
        projectile.GetComponent<GameObject>();
        //projectile.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + 90);
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBetweenSpawn <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            //transform.eulerAngles = new Vector3(0, 0, 90);
            
            //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + 90);
            timeBetweenSpawn = startTimeBetweenSpawn;
            
        }
        else
        {
            timeBetweenSpawn -= Time.deltaTime;
        }

        
    }

   
    
}
