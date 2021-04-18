using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public GameObject tankTowerPrefab;
    public int health;
    public float angle;
    public float power;
    public int attack;

    public bool isFiring;

    public AudioClip shootSound;
    public GameObject projectile;

    private AudioSource source;

    public void Start()
    {
        health = 5;
    }

    public void AdjustTowerAngle(float degree)
    {
        tankTowerPrefab.transform.transform.localRotation = Quaternion.Euler(degree, 0, 0);
    }

    public void SetHealth(int health)
    {
        this.health = health;
    }

    public void TakeDamage(int enemyAttack)
    {
        health -= enemyAttack;
    }

    public void SetAttack(int attack)
    {
        this.attack = attack;
    }

    public void FireProjectile()
    { 
        if (!isFiring)
        {
            isFiring = true;

            float vol = 10;
            source = GetComponent<AudioSource>();
            source.PlayOneShot(shootSound, vol);

            GameObject shootMissile = Instantiate(projectile, tankTowerPrefab.transform.transform.position + new Vector3(0, 0.4f, 0), tankTowerPrefab.transform.transform.rotation);
            shootMissile.GetComponent<Missile>().firedBy = this;
            shootMissile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, power * 2000));
        }
    }
}