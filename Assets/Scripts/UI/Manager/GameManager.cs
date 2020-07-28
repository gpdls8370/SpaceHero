using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int stageNum;
    public static int currentSaveNum;
    public static int targetSaveNum;

    public static int currentLife;
    public static int maxLife;

    public static int coin;

    public static float barSpeed;
    public static float ballSpeed;
    public static float timeScale;

    public static GameManager Instance;

    // 시작 값 조정
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        stageNum = -1;
        currentSaveNum = -1;
        targetSaveNum = -1;

        currentLife = -1;
        maxLife = -1;

        coin = 50;

        barSpeed = 4f;
        ballSpeed = 300f;
        timeScale = 1f;
    }
}
