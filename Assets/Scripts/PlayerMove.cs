using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    void Update()
    {
        transform.position = new Vector2(GameObject.Find("Bar").gameObject.transform.position.x, transform.position.y);
    }
}
