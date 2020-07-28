using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBtn : MonoBehaviour
{
    public static bool isPause;
    public GameObject pauseCanvas;

    private void Awake()
    {
        isPause = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPause && !OptionManager.isOption && !AlertManager.isAlert)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        isPause = true;
        Time.timeScale = 0f;
        pauseCanvas.SetActive(true);
    }
}
