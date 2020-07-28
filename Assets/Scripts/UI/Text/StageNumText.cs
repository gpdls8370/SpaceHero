using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageNumText : MonoBehaviour
{
    public Text stageNum;

    void Start()
    {
        stageNum.text = GameManager.stageNum.ToString();
    }

    void Update()
    {
        stageNum.text = GameManager.stageNum.ToString();
    }
}
