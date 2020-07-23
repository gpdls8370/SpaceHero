using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    public static float barSpeed;
    public static float ballSpeed;
    public GameObject optionCanvas;

    private void Awake()
    {
        barSpeed = 4f;
        ballSpeed = 300f;

        optionCanvas = GameObject.Find("OptionCanvas");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "MainScene")
        {
            Debug.Log("Escape");
            Time.timeScale = 0f;
            optionCanvas.SetActive(true);
        }
    }
}
