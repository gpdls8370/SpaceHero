using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBallTrigger : MonoBehaviour
{
    public bool ghostBall = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ghostBall == true)
        {
            if (collision.gameObject.tag == "Brick")
            {
                collision.gameObject.GetComponent<Brick>().brickLife--;
                if (collision.gameObject.GetComponent<Brick>().brickLife <= 0)
                {
                    Destroy(collision.gameObject);
                }
            }

            else if (collision.gameObject.tag == "AlienIce")
            {
                collision.gameObject.GetComponent<Brick>().brickLife--;
                if (collision.gameObject.GetComponent<Brick>().brickLife <= 0)
                {
                    Destroy(collision.gameObject);
                }
                Instantiate(Resources.Load("Prefabs/Alien"), new Vector2(collision.transform.position.x, collision.transform.position.y), Quaternion.identity);
            }

            else if (collision.gameObject.tag == "ItemIce")
            {
                collision.gameObject.GetComponent<Brick>().brickLife--;
                if (collision.gameObject.GetComponent<Brick>().brickLife <= 0)
                {
                    Destroy(collision.gameObject);
                }
                Instantiate(Resources.Load("Prefabs/Item"), new Vector2(collision.transform.position.x, collision.transform.position.y), Quaternion.identity);
            }
        }
    }
}
