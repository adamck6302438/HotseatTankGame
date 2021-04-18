﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider angleSlider;
    public Slider powerSlider;

    public static int activeTankIndex;

    public Tank tankleft;
    public Tank tankRight;

    public static List<Tank> tankList = new List<Tank>();

    public Button buttonLeft;
    public Button buttonRight;
    public Button fireButton;

    public GameObject platformLeft;
    public GameObject platformRight;

    public AudioClip gameOverSound;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();

        GenerateTerrain();

        //Initialization
        powerSlider.value = 0.4f;
        angleSlider.value = 40;

        tankleft.angle = angleSlider.value;
        tankleft.power = powerSlider.value;

        tankRight.angle = angleSlider.value;
        tankRight.power = powerSlider.value;

        tankList.Add(tankleft);
        tankList.Add(tankRight);
        activeTankIndex = 0;

        //UI hook up
        tankleft.name = "Player Left";
        tankRight.name = "Player Right";
        fireButton.onClick.AddListener(Fire);
        //buttonLeft.onClick.AddListener(MoveLeft);
        //buttonRight.onClick.AddListener(MoveRight);

    }

    // Update is called once per frame
    void Update()
    {
        //TankControl();
        //update the angle of the tank tower
        tankList[activeTankIndex].AdjustTowerAngle(-angleSlider.value);

        //keep checking to see if any tank's health reaches 0
        CheckWinner();
    }

    void Fire()
    {
        Debug.Log("Fire");
        Debug.Log("Angle: " + angleSlider.value);
        Debug.Log("Power: " + powerSlider.value);
        tankList[activeTankIndex].angle = angleSlider.value;
        tankList[activeTankIndex].power = powerSlider.value;
        tankList[activeTankIndex].FireProjectile();

        activeTankIndex = (activeTankIndex + 1) % 2;
        Debug.Log("Current Player: " + tankList[activeTankIndex].name);
        angleSlider.value = tankList[activeTankIndex].angle;
        powerSlider.value = tankList[activeTankIndex].power;
    }

    //Modify this part to be event
    /*public void MoveLeft()
    {
        Debug.Log("Move left");
        tankList[activeTankIndex].MoveLeft();
    }*/

    /*public void MoveRight()
    {
        Debug.Log("Move right");
        tankList[activeTankIndex].MoveRight();
    }*/

    public void TankControl()
    {
        //Add control for keyboard
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
        {
            tankList[activeTankIndex].transform.position -= new Vector3(5, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
        {
            tankList[activeTankIndex].transform.position += new Vector3(5, 0, 0) * Time.deltaTime;
        }
    }

    public void GenerateTerrain()
    {
        //Generate platform for tanks with random heights
        platformLeft.transform.localScale += new Vector3(0, Random.Range(0, 3), 0);
        platformRight.transform.localScale += new Vector3(0, Random.Range(0, 3), 0);
        Debug.Log(platformLeft.transform.localScale.y);
        Debug.Log(platformRight.transform.localScale.y);
        tankleft.transform.position = new Vector3(-38, platformLeft.transform.localScale.y*2+0.8f, 0);
        tankleft.GetComponent<Rigidbody>().isKinematic = true;
        tankleft.GetComponent<Rigidbody>().drag = 1000;
        tankRight.transform.position = new Vector3(38, platformRight.transform.localScale.y*2+0.8f, 0);
        tankRight.GetComponent<Rigidbody>().isKinematic = true;
        tankRight.GetComponent<Rigidbody>().drag = 1000;
        //Generate destrutable 'terrain' made of cubes randomly
        for (int i = -35; i < 35; i++)
        {
            for (int j = 0; j < Random.Range(0, 30); j++)
            {
                GameObject terrainCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Rigidbody terrainCubeRb = terrainCube.AddComponent<Rigidbody>();
                terrainCubeRb.drag = 1000;
                terrainCubeRb.isKinematic = true;
                BoxCollider terrainCubeCollider = terrainCube.AddComponent<BoxCollider>();
                terrainCube.tag = "terrain";
                terrainCube.transform.position = new Vector3(i, j, 0);
                terrainCube.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }

    public void CheckWinner()
    {
        if (tankList[(activeTankIndex == 0 ? 1 : 0)].health == 0)
        {
            Debug.Log("Winner is: " + tankList[activeTankIndex].name);
            source.PlayOneShot(gameOverSound, 10);
        }
    }


}
