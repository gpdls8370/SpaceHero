using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusLife : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Bar")
        {
            if(GameObject.Find("GameManager").GetComponent<Life>().playerLife < GameObject.Find("GameManager").GetComponent<Life>().maxPlayerLife)
            GameObject.Find("GameManager").GetComponent<Life>().playerLife++;
            GameObject.Find("GameManager").GetComponent<Life>().LifeIcon[GameObject.Find("GameManager").GetComponent<Life>().playerLife - 1].SetActive(true);
        }
    }
}
