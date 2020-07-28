using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionManager : MonoBehaviour
{
    public static GameObject optionCanvas;
    public static OptionManager Instance;
    public static bool isOption;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        optionCanvas = GameObject.Find("OptionCanvas");
        optionCanvas.SetActive(false);
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && OptionManager.isOption && SceneManager.GetActiveScene().name != "MainScene")
        {
            TurnOffOptionMenu();
        }
    }

    public static void TurnOnOptionMenu()
    {
        isOption = true;
        optionCanvas.SetActive(true);
    }

    public static void TurnOffOptionMenu()
    {
        isOption = false;
        optionCanvas.SetActive(false);
    }
}
