using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetBtn : MonoBehaviour
{
    public GameObject barSpeedField;
    public GameObject ballSpeedField;

    public void ResetSpeed()
    {
        barSpeedField.GetComponent<InputField>().text = "4";
        GameManagement.barSpeed = 4f;

        ballSpeedField.GetComponent<InputField>().text = "200";
        GameManagement.ballSpeed = 200f;
    }
}
