using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    public bool BombBallOn = false;
    public int BombCount = 0;
    public GameObject[] BombIcon;
    private GameObject[] ball;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (BombCount > 0 && BombBallOn == false)
            {
                BombCount--;
                GameObject.Find("ItemManager").GetComponent<BombManager>().BombIcon[BombCount].SetActive(false);
                ball = GameObject.FindGameObjectsWithTag("Ball");      //폭탄공으로 바꿔줌

                for(int i = 0; i < ball.Length; i++) 
                {
                    ball[i].gameObject.tag = "BombBall";
                }
                BombBallOn = true;
            }
        }
    }
}
