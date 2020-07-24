using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    public GameObject optionCanvas;

    public void MoveToMainScene()
    {
        DontDestroyOnLoad(optionCanvas);
        optionCanvas.SetActive(false);

        if (GameManagement.barSpeed <= 0f)
        {
            GameManagement.barSpeed = 4f;
        }
        if (GameManagement.ballSpeed <= 0f)
        {
            GameManagement.ballSpeed = 200f;
        }

        SceneManager.LoadScene("MainScene");
    }
}
