using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionBtn : MonoBehaviour
{
    public void MoveToOptionMenu()
    {
        OptionManager.TurnOnOptionMenu();
    }

    public void MoveToMainMenu()
    {
        OptionManager.TurnOffOptionMenu();
    }
}
