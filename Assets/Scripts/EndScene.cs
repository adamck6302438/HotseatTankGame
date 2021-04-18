using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    // Start is called before the first frame update
    public Text result;
    void Start()
    {
        result.text = "Winner is: " + GameController.winner;
    }
}
