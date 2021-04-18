using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);
    }

    //Add to bullet script
    void OnCollisionEnter(Collision col)
    {
        switch (col.gameObject.tag)
        {
            case "terrain":
                Destroy(col.gameObject);
                Destroy(this.gameObject);
                break;
            case "floor":
                Destroy(this.gameObject);
                break;
            case "tank":
                col.gameObject.GetComponent<Tank>().health--;
                Destroy(gameObject);
                break;
            case "powerup":

                break;
        }
    }
}
