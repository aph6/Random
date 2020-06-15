﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//In this example, the name of the GameObject that collides with your GameObject is output to the console. Then this checks the name of the Collider and if it matches with the one you specify, it outputs another message.

//Create a GameObject and make sure it has a Collider component. Attach this script to it.
//Create a second GameObject with a Collider and place it on top of the other GameObject to output that there was a collision. You can add movement to the GameObject to test more.


public class Collision : MonoBehaviour
{
    //If your GameObject starts to collide with another GameObject with a Collider


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
    }

}