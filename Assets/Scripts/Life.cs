using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Update()
    {
        if (playerLife == 0)
        {
            //게임오버
            Application.Quit();
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }

}
