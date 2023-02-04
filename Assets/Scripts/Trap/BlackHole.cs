using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    private Animator blackHoleBrickAni;

    private void Start()
    {
        blackHoleBrickAni = GetComponent<Animator>();
    }

    private void blackHoleEvent()
    {
        Destroy(this.gameObject);
        Instantiate(Resources.Load("Prefabs/Trap/BlackHoleRange"), transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            blackHoleBrickAni.enabled = true;
        }
    }
}
