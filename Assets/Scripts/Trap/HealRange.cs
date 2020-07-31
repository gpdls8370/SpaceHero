using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealRange : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Brick")
        {
            collision.gameObject.GetComponent<Brick>().brickLife = collision.gameObject.GetComponent<Brick>().brickLife + 1;
            this.gameObject.SetActive(false);
        }
    }
}
