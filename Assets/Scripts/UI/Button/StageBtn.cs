using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageBtn : MonoBehaviour
{
    public GameObject stageCanvas;

    public void MoveToMainScene(int stageNum)
    {
        // GameManager.cs 에 아예 선언하여 더 깔끔하게 할 수 있음, 임시로 이렇게 해둠
        if (stageNum == 1)
        {
            GameManager.stageNum = 1;
            GameManager.currentSaveNum = 0;
            GameManager.targetSaveNum = 3;
            GameManager.currentLife = 3;
            GameManager.maxLife = 3;
            GameManager.barSpeed = 4f;
            GameManager.ballSpeed = 300f;
        }
        else if (stageNum == 2)
        {
            GameManager.stageNum = 2;
            GameManager.currentSaveNum = 0;
            GameManager.targetSaveNum = 5;
            GameManager.currentLife = 3;
            GameManager.maxLife = 3;
            GameManager.barSpeed = 4f;
            GameManager.ballSpeed = 300f;
        }
        else if (stageNum == 3)
        {
            GameManager.stageNum = 3;
            GameManager.currentSaveNum = 0;
            GameManager.targetSaveNum = 10;
            GameManager.currentLife = 3;
            GameManager.maxLife = 3;
            GameManager.barSpeed = 4f;
            GameManager.ballSpeed = 300f;
        }
        else if (stageNum == 4)
        {
            GameManager.stageNum = 4;
            GameManager.currentSaveNum = 0;
            GameManager.targetSaveNum = 20;
            GameManager.currentLife = 3;
            GameManager.maxLife = 1;
            GameManager.barSpeed = 4f;
            GameManager.ballSpeed = 300f;
        }
        else
        {
            return;
        }

        StartCoroutine(WaitForLoading("MainScene"));
    }

    public IEnumerator WaitForLoading(string SceneName)
    {
        Time.timeScale = GameManager.timeScale;

        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(SceneName);
        yield return new WaitUntil(() => loadingOperation.isDone);

        Destroy(stageCanvas);
    }
}
