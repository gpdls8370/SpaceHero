using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int brickLife;

    private void hitBrick()
    {
        brickLife--;
        if (brickLife <= 0)
        {
            if (this.gameObject.tag == "Brick")
            {
                Destroy(this.gameObject);
            }

            else if (this.gameObject.tag == "AlienIce")
            {
                Destroy(this.gameObject);
                Instantiate(Resources.Load("Prefabs/Alien"), new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            }

            else if (this.gameObject.tag == "ItemIce")
            {
                Destroy(this.gameObject);
                Instantiate(Resources.Load("Prefabs/Item"), new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            }
        }   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //박스가 공이랑 부딪히면 없애기
        if(collision.gameObject.tag == "Ball")
        {
            hitBrick();
        }

        if(collision.gameObject.tag == "BombBall")
        {
            //주변 8칸 박스 목숨 까기
            
            collision.gameObject.tag = "Ball";
            GameObject.Find("ItemManager").GetComponent<BombManager>().BombBallOn = false;
            GameObject.Find("ItemManager").transform.Find("BombRangeTrigger").gameObject.SetActive(true);
            GameObject.Find("BombRangeTrigger").gameObject.transform.position = this.transform.position;
        }
    }
}
