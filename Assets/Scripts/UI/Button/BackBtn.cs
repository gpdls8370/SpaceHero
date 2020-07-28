using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackBtn : MonoBehaviour
{
    public GameObject stageCanvas;

    public void MoveToStartScene()
    {
        StartCoroutine(WaitForLoading("StartScene"));
    }

    public void MoveToStageScene()
    {
        StartCoroutine(WaitForLoading("StageScene"));
    }

    public IEnumerator WaitForLoading(string SceneName)
    {
        Time.timeScale = 1f;

        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(SceneName);
        yield return new WaitUntil(() => loadingOperation.isDone);

        Destroy(stageCanvas);
    }
}
