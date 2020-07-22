using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetBtn : MonoBehaviour
{
    public GameObject barSpeed;
    public GameObject ballSpeed;

    public void ResetSpeed()
    {
        barSpeed.GetComponent<InputField>().text = "4";
        ballSpeed.GetComponent<InputField>().text = "300";
    }
}
