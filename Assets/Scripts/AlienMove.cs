using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class AlienMove : MonoBehaviour
{
    private Animator ani;
    private GameObject SavedAlien;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "ButtomWall")
        {
            ani = this.GetComponent<Animator>();
            ani.runtimeAnimatorController = RuntimeAnimatorController.Instantiate(Resources.Load("Ani/AlienWalk")) as RuntimeAnimatorController;
               
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector2(2, 0);
        }

        else if (collision.gameObject.name == "RightWall")
        {
            Destroy(this.gameObject);
            //SavedAlien = Instantiate(Resources.Load("Prefabs/SavedAlien"), new Vector2(Random.Range(540, 680), Random.Range(45, 145)), Quaternion.identity) as GameObject;
            //float x = 363.34f,y= -151f;
            //float x=GameObject.Find("GameCanvas").GetComponent<RectTransform>().position.x+ GameObject.Find("SavedThings").GetComponent<RectTransform>().position.x;
            //float y= GameObject.Find("GameCanvas").GetComponent<RectTransform>().position.y + GameObject.Find("SavedThings").GetComponent<RectTransform>().position.y;
            GameManager.currentSaveNum = GameManager.currentSaveNum + 1;

            if (GameManager.currentSaveNum == GameManager.targetSaveNum)
            {
                SceneManager.LoadScene("StageScene");
            }
            float width = GameObject.Find("SavedThings").GetComponent<RectTransform>().rect.width/2;
            float height = GameObject.Find("SavedThings").GetComponent<RectTransform>().rect.height/2;
            float x = GameObject.Find("SavedThings").GetComponent<RectTransform>().position.x;
            float y =  GameObject.Find("SavedThings").GetComponent<RectTransform>().position.y;
            SavedAlien = Instantiate(Resources.Load("Prefabs/SavedAlien"), new Vector2(Random.Range(x-width,x+width), Random.Range(y-height,y+height)), Quaternion.identity) as GameObject;
            SavedAlien.transform.SetParent(GameObject.Find("SavedThings").transform);
        }
    }
}
