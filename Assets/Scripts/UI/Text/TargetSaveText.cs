using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetSaveText : MonoBehaviour
{
    public Text targetSave;

    void Start()
    {
        targetSave.text = GameManager.targetSaveNum.ToString();
    }

    void Update()
    {
        targetSave.text = GameManager.targetSaveNum.ToString();
    }
}
