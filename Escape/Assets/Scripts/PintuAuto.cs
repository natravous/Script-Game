﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PintuAuto : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //gameObject.SetActive(false);
            anim.SetBool("BukaPintu", true);
        }
    }
}
