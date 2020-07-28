using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeBtn : MonoBehaviour
{
    public GameObject pauseCanvas;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && PauseBtn.isPause && !OptionManager.isOption && !AlertManager.isAlert)
        {
            ResumeGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && OptionManager.isOption)
        {
            OptionManager.TurnOffOptionMenu();
        }
    }

    public void ResumeGame()
    {
        PauseBtn.isPause = false;
        Time.timeScale = GameManager.timeScale;
        pauseCanvas.SetActive(false);
    }
}
