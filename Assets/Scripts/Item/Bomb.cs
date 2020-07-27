using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private int bombNum;
    public int maxBombCount = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bar")
        {
            //폭탄 아이템 먹으면 카운트 올려주고 화면에 폭탄 사용 가능하다는 걸 표시
            if (GameObject.Find("ItemManager").GetComponent<BombManager>().BombCount < maxBombCount)
            {
                GameObject.Find("ItemManager").GetComponent<BombManager>().BombCount++;
                GameObject.Find("BombIcon").GetComponent<BombManager>().BombIcon[GameObject.Find("ItemManager").GetComponent<BombManager>().BombCount - 1].SetActive(true);   //아이콘 보이게
            }
        }
    }
}
