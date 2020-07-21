using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMove : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "ButtomWall")
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0);
        }

        else if (collision.gameObject.name == "RightWall")
        {
            Destroy(this.gameObject);
        }
    }
}
