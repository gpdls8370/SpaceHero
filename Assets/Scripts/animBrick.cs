using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animBrick : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 박스가 공이랑 부딪히면 애니메이션이 나온 후 없애기
        if (collision.gameObject.tag == "Ball")
        {
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            anim.SetTrigger("Destroyed");
        }
    }
}
