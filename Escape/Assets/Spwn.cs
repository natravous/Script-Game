using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwn : MonoBehaviour
{
    public float spwnrt = 1f;

    public GameObject prefab;

    private float nextTimeSpwn = 0f;

    private float lineTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Time.time >= nextTimeSpwn)
        //{
        //    Instantiate(prefab, Vector3.zero, Quaternion.identity);
        //    nextTimeSpwn = Time.time + 1f / spwnrt;
        //}

        if (lineTime <= 0)
            Spwnnn();

        lineTime -= Time.deltaTime;
    }

    private void Spwnnn()
    {
        Instantiate(prefab, Vector3.zero, Quaternion.identity);
        lineTime = Random.Range(15f, 60f);
    }
}
