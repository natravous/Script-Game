using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    private GameMaster gm;
    private CameraFollow cam;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gm.lastCheckPointPos = transform.position;
            gm.camPos = transform.position;
        }
    }
}
