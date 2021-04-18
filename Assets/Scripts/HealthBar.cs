﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    //Fields
    public string tankColour; //colour of tank below healthBar
    public float healthSize; //size of healthBar 
    public GameObject tank; //GameObject of tank below the health bar

    // Start is called before the first frame update
    void Start()
    {
        tank = GameObject.Find($"TankFree_{tankColour}");
        healthSize = tank.GetComponent<Tank>().health;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(tank.transform.position.x, tank.transform.position.y+4, tank.transform.position.z);
        this.transform.localScale = new Vector3(tank.GetComponent<Tank>().health, 1, 1);
    }
}
