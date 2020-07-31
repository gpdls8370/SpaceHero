using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Instantiate(Resources.Load("Prefabs/Trap/BlackHoleRange"), transform.position, Quaternion.identity);

        }
    }
}
