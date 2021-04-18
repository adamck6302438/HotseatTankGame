using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    //Variables for powerup
    public int powerId; //id of the powerup, used to determine whether it is a health or damage powerup
    int powerVal; //the value of the powerup's increase

    // Update is called once per frame
    void Update()
    {
        //check for powerId to determine what tank's powerVal is
        if (powerId == 1) //id of 1 makes tank stat increase health to 5
        {
            powerVal = 5;
        }
        else if (powerId == 2) //id of 2 makes tank stat increase attack by 3
        {
            powerVal = 3;
        }
    }
}
