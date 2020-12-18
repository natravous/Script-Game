using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coba : MonoBehaviour
{

    public Transform point;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    Shoot();
        //}
        Shoot();

    }

    void Shoot()
    {
        Instantiate(prefab, point.position, point.rotation);

        Random.Range(15f, 60f);
    }
}
