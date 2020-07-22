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
        SceneManager.LoadScene("MainScene");
    }
}
