using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animBrick : MonoBehaviour
{
    public int brickLife;

    private Animator anim;
    private AudioSource sound;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        sound = gameObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 박스가 공이랑 부딪히면 애니메이션이 나온 후 없애기
        if (collision.gameObject.tag == "Ball")
        {
            brickLife -= 1;
            if (brickLife <= 0)
            {
                sound.Play();

                Destroy(gameObject.GetComponent<BoxCollider2D>());
                anim.SetTrigger("Destroyed");
            }
        }
    }
}
