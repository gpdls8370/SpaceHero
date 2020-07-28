using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeScript : MonoBehaviour
{
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

    void Start()
    {
        /*
        life1.SetActive(true);
        life2.SetActive(true);
        life3.SetActive(true);
        */
    }

    void Update()
    {
        // 아래 코드는 임시로 작성한 것, 실제로는 피해를 입는 부분에 SetActive 관련 코드를 넣어야 함.
        /*
        if (GameManager.currentLife <= 2)
        {
            life3.SetActive(false);
        }
        else if (GameManager.currentLife <= 1)
        {
            life2.SetActive(false);
        }
        else if (GameManager.currentLife <= 0)
        {
            life1.SetActive(false);
        }
        */
    }
}
