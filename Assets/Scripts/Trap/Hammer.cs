using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public GameObject target;
    private Animator hammerAni;

    private void Update()
    {
        if (target != null)
        {
            transform.position = Vector2.Lerp(transform.position, target.transform.position, 0.05f);
        }

        if (transform.position == target.transform.position)
        {
            Destroy(this.gameObject);
            target.transform.GetChild(0).GetComponent<Animator>().enabled = true;
        }
    }
}
