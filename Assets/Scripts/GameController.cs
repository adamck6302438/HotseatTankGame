using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public int counter = 0;

    void Start()
    {
        //Initialization
        tankleft.previousAngle = 0;
        tankRight.previousAngle = 0;
        tankleft.previousPower = 0;
        tankRight.previousPower = 0;
        tankList.Add(tankleft);
        tankList.Add(tankRight);
        activeTankIndex = 0;

        //UI hook up
        tankleft.name = "Player Left";
        tankRight.name = "Player Right";
        fireButton.onClick.AddListener(Fire);
        buttonLeft.onClick.AddListener(MoveLeft);
        buttonRight.onClick.AddListener(MoveRight);
    }

    // Update is called once per frame
    void Update()
    {
        //update the angle of the tank tower
        tankList[activeTankIndex].AdjustTowerAngle(angleSlider.value);

        //keep checking to see if 
        if (tankList[(activeTankIndex == 0 ? 1 : 0)].health == 0)
        {
            Debug.Log("Winner is: " + tankList[activeTankIndex].name);
        }
    }

    void Fire()
    {
        //1. Pass the angle and power into calculation of projectile
        Debug.Log("Fire");
        Debug.Log("Angle: " + angleSlider.value);
        Debug.Log("Power: " + powerSlider.value);
        tankList[activeTankIndex].previousAngle = angleSlider.value;
        tankList[activeTankIndex].previousPower = powerSlider.value;
        //2. Check triggers for hovering power ups and hits


        //3. Switch player and check if any player reaches 0 health
        activeTankIndex = (activeTankIndex == 0 ? 1 : 0);
        Debug.Log("Current Player: " + tankList[activeTankIndex].name);
        angleSlider.value = tankList[activeTankIndex].previousAngle;
        powerSlider.value = tankList[activeTankIndex].previousPower;
    }

    public void MoveLeft()
    {
        Debug.Log("Move left");
        tankList[activeTankIndex].transform.position -= new Vector3(1f, 0, 0);
    }

    public void MoveRight()
    {
        Debug.Log("Move right");
        tankList[activeTankIndex].transform.position += new Vector3(1f, 0, 0);
    }
}
