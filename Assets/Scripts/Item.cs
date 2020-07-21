using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Bar")
        {
            Destroy(this.gameObject);
        }

        else if (collision.gameObject.name == "ButtomWall")
        {
            Destroy(this.gameObject);
        }
    }


}
