using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertBtn : MonoBehaviour
{
    public GameObject alertCanvas;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && AlertManager.isAlert && !PauseBtn.isPause && !OptionManager.isOption)
        {
            ExitAlert();
        }
    }

    public void ExitAlert()
    {
        AlertManager.isAlert = false;
        Time.timeScale = GameManager.timeScale;
        alertCanvas.SetActive(false);
    }
}
