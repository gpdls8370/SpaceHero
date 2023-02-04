using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCrack : MonoBehaviour
{
    private SpriteRenderer crackSR;
    public Sprite[] crack;

    private GameObject parentStone;
    private int parentLife;

    private void Start()
    {
        parentStone = transform.parent.gameObject;
        parentLife = parentStone.GetComponent<Brick>().brickLife;
        crackSR = GetComponent<SpriteRenderer>();
    }

    public void Crack()
    {
        if (parentStone.GetComponent<Brick>().brickLife == parentStone.GetComponent<Brick>().initialBrickLife)
        {
            crackSR.sprite = crack[0];
            parentStone.GetComponent<Brick>().isCracked = false;
        }
        else
        {
            crackSR.sprite = crack[parentStone.GetComponent<Brick>().brickLife];
        }
    }

    private void HammerEvent()
    {
        GetComponent<Animator>().enabled = false;
        parentStone.GetComponent<Brick>().isHealing = false;
        Crack();
        
    }
}
