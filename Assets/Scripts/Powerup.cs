using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private void Start()
    {
        transform.position = new Vector3(Random.Range(-38, 38), Random.Range(15, 20), 0);
    }
}
