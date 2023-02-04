using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;

public class BombRange : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Brick>().brickLife--;
        if(collision.gameObject.GetComponent<Brick>().brickLife <= 0)
        {
            if (collision.gameObject.tag == "Stone" || collision.gameObject.tag == "Ice")
            {
                Destroy(collision.gameObject);
            }

            else if (collision.gameObject.tag == "AlienIce")
            {
                Destroy(collision.gameObject);
                Instantiate(Resources.Load("Prefabs/Alien"), new Vector2(collision.transform.position.x, collision.transform.position.y), Quaternion.identity);
            }

            else if (collision.gameObject.tag == "ItemIce")
            {
                Destroy(collision.gameObject);
                Instantiate(Resources.Load("Prefabs/Item"), new Vector2(collision.transform.position.x, collision.transform.position.y), Quaternion.identity);
            }
        }

        this.gameObject.SetActive(false);

    }
}