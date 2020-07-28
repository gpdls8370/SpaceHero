using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    public GameObject mainCanvas;
    private AudioSource sound;

    private void Start()
    {
        DontDestroyOnLoad(mainCanvas);
        sound = gameObject.GetComponent<AudioSource>();
    }

    public void MoveToMainScene()
    {
        StartCoroutine(WaitForSound());
    }

    public IEnumerator WaitForSound()
    {
        SceneManager.LoadScene("StageScene");
        yield return new WaitUntil(() => sound.isPlaying == false);
        Destroy(mainCanvas);
    }
}
