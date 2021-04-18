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

    public AudioClip shootSound;
    public GameObject projectile;

    private AudioSource source;

    public void Start()
    {
        health = 5;
    }

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
        angle = degree;
        tankTowerPrefab.transform.transform.localRotation = Quaternion.Euler(degree, 0, 0);
    }

    public void ResetToFullHealth()
    {
        health = 5;
    }

    public void TakeDamage(int enemyAttack)
    {
        health -= enemyAttack;
    }

    public void PowerUp()
    {
        attack = 3;
    }

    public void FireProjectile()
    { 
        float vol = 10;
        source = GetComponent<AudioSource>();
        source.PlayOneShot(shootSound, vol);

        GameObject shootMissile = Instantiate(projectile, tankTowerPrefab.transform.transform.position + new Vector3(0,0.4f,0), tankTowerPrefab.transform.transform.rotation);
        Missile missile = shootMissile.AddComponent<Missile>();
        missile.firedBy = this;
        shootMissile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,0,power * 2000));
    }
}