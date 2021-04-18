using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Tank firedBy;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);
    }

    //Add to bullet script
    void OnCollisionEnter(Collision col)
    {
        GameController gameCtrl = GameObject.Find("GameController").GetComponent<GameController>();

        switch (col.gameObject.tag)
        {
            case "terrain":
                Destroy(col.gameObject);
                break;
            case "AtkPwrUp":
                Destroy(col.gameObject);
                firedBy.PowerUp();
                break;
            case "HpPwrUp":
                Destroy(col.gameObject);
                firedBy.ResetToFullHealth();
                break;
            case "tank":
                col.gameObject.GetComponent<Tank>().TakeDamage(firedBy.attack);
                break;
        }

        gameCtrl.EndTurn();
        Destroy(gameObject);
    }
}
