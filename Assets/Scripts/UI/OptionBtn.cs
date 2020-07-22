using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionBtn : MonoBehaviour
{
    public GameObject optionCanvas;

    public GameObject barSpeed;
    public GameObject ballSpeed;

    public void MoveToOptionMenu()
    {
        optionCanvas.SetActive(true);
    }

    public void MoveToMainMenu()
    {
        optionCanvas.SetActive(false);
    }
}
