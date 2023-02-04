using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealRange : MonoBehaviour
{
    private GameObject Hammer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stone")
        {
            if (collision.GetComponent<Brick>().isCracked == true && collision.GetComponent<Brick>().isHealing == false)
            {
                collision.GetComponent<Brick>().isHealing = true;
                Hammer = Instantiate(Resources.Load("Prefabs/Trap/Hammer"), transform.position, Quaternion.identity) as GameObject;
                Hammer.GetComponent<Hammer>().target = collision.gameObject;

                collision.gameObject.GetComponent<Brick>().brickLife = collision.gameObject.GetComponent<Brick>().brickLife + 1;
                this.gameObject.SetActive(false);
            }
        }
    }


  
}
