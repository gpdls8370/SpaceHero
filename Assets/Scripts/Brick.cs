using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //박스가 공이랑 부딪히면 없애기
        if(collision.gameObject.tag == "Ball")
        {
            Destroy(this.gameObject);
        }
    }
}
