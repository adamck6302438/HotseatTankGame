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
        Debug.Log("Collision Enter: " + name + " with " + col.gameObject.tag);

        GameController gameCtrl = GameObject.Find("GameController").GetComponent<GameController>();

        switch (col.gameObject.tag)
        {
            case "terrain":
                Destroy(col.gameObject);
                break;
            case "AtkPwrUp":
                Destroy(col.gameObject);
                firedBy.SetAttack(3);
                break;
            case "HpPwrUp":
                Destroy(col.gameObject);
                firedBy.SetHealth(5);
                break;
            case "tank":
                col.gameObject.GetComponent<Tank>().TakeDamage(firedBy.attack);
                break;
            default:
                break;
        }

        // reset attack power up after one turn
        if (firedBy.attack > 1 && !col.gameObject.CompareTag("HpPwrUp"))
        {
            firedBy.SetAttack(1);
        }

        firedBy.isFiring = false;
        gameCtrl.EndTurn();
        Destroy(gameObject);
    }
}
