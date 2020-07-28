using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentSaveText : MonoBehaviour
{
    public Text currentSave;

    void Start()
    {
        currentSave.text = GameManager.currentSaveNum.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        currentSave.text = GameManager.currentSaveNum.ToString();
    }
}
