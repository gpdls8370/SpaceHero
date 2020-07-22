using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionBtn : MonoBehaviour
{
    public GameObject optionCanvas;

    public GameObject barSpeedField;
    public GameObject ballSpeedField;

    public void MoveToOptionMenu()
    {
        optionCanvas.SetActive(true);
    }

    public void MoveToMainMenu()
    {
        GameManagement.barSpeed = float.Parse(barSpeedField.GetComponent<InputField>().text);
        GameManagement.ballSpeed = float.Parse(ballSpeedField.GetComponent<InputField>().text);
        optionCanvas.SetActive(false);
        Time.timeScale = 1f;
    }
}
