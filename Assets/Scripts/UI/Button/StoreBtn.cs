using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreBtn : MonoBehaviour
{
    public GameObject stageCanvas;
    private AudioSource sound;

    private void Start()
    {
        DontDestroyOnLoad(stageCanvas);
        sound = gameObject.GetComponent<AudioSource>();
    }

    public void MoveToStoreScene()
    {
        StartCoroutine(WaitForSound());
    }

    public IEnumerator WaitForSound()
    {
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync("StoreScene");
        yield return new WaitUntil(() => loadingOperation.isDone);
        StoreManager.ChangeSell();

        yield return new WaitUntil(() => sound.isPlaying == false);
        Destroy(stageCanvas);
    }
}
