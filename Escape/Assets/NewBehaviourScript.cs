﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            StaminaBar.instance.UseStamina(15);
        }
    }
}
