using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tankTowerPrefab;
    public float power;
    public int health;
    public float previousAngle;
    public float previousPower;

    public AudioClip shootSound;
    public GameObject projectile;

    private AudioSource source;

    public void MoveLeft()
    {
        this.transform.position -= new Vector3(1f, 0, 0);
    }

    public void MoveRight()
    {
        this.transform.position += new Vector3(1f, 0, 0);
    }

    public void AdjustTowerAngle(float degree)
    {
        tankTowerPrefab.transform.transform.localRotation = Quaternion.Euler(degree, 0, 0);
    }

    public void FireProjectile()
    {
        float vol = 10;
        source = GetComponent<AudioSource>();
        source.PlayOneShot(shootSound, vol);
    }

    //Add to bullet script
    /*    void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "terrain")
            {
                Destroy(col.gameObject);
                Destroy(this.gameObject);
            }
        }*/
}
