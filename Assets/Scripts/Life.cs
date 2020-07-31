using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Life : MonoBehaviour
{
    public int playerLife;
    public int maxPlayerLife;
    public GameObject[] LifeIcon;

    private void Start()
    {
        for(int i = 0; i < playerLife; i++)
        {
            LifeIcon[i].SetActive(true);
        }
    }

    public void stageOver()
    {
        //게임오버 (추가해야함)
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

    }

    public void minusLife(GameObject damageBall)
    {
        //하나밖에 안남았는데 점수깎이면 목숨 하나 깎기
        if(GameManager.ballCount == 1)
        {
            Destroy(damageBall.gameObject);
            playerLife--;
            LifeIcon[playerLife].SetActive(false);
            Instantiate(Resources.Load("Prefabs/Ball"), new Vector2(GameObject.Find("Bar").transform.position.x, -1.5f), Quaternion.identity);
        }

        else
        {
            Destroy(damageBall.gameObject);
        }

        if (playerLife == 0)
        {
            stageOver();
        }
    }
}
