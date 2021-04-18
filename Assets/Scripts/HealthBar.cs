using System.Collections;
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
        tank = GameObject.Find($"TankFree_{tankColour}"); //select tank object based on color
        healthSize = tank.GetComponent<Tank>().health; //size of healthbar is selected from the tank object chosen
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(
            tank.transform.position.x,
            this.transform.position.y,
            this.transform.position.z
            ); //healthbar moves with tank
        this.transform.localScale = new Vector3(healthSize, 1, 1); //healthbar size adjusts to health of tank
    }
}
