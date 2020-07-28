using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 블록의 종류에 따라 경고 메시지를 변경하고 싶다면 이 스크립트의 OnCollisionEnter2D 를 참고하여 수정할 것
public class BallMove : MonoBehaviour
{
    public float speed;
    public GameObject alertCanvas;
    public GameObject alertText;

    private Rigidbody2D BallRb;
    private AudioSource sound;

    void Start()
    {
        speed = 200;
        //speed = GameManagement.ballSpeed;

        BallRb = GetComponent<Rigidbody2D>();
        BallRb.isKinematic = false;
        BallRb.AddForce(new Vector2(0, speed));

        sound = gameObject.GetComponent<AudioSource>();
    }

    private void ShowAlert(string tagName, string message)
    {
        AlertManager.isAlert = true;
        Alerted.Things[tagName] = true;
        alertText.GetComponent<Text>().text = message;

        Time.timeScale = 0f;
        alertCanvas.SetActive(true);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "ButtomWall")
        {
            GameObject.Find("GameManager").GetComponent<Life>().playerLife--;
            GameObject.Find("GameManager").GetComponent<Life>().LifeIcon[GameObject.Find("GameManager").GetComponent<Life>().playerLife].SetActive(false);
        }

        if (collision.gameObject.tag == "Wall" || collision.gameObject.name == "Bar")
        {
            sound.Play();
        }
        if (collision.gameObject.tag == "Stone" && !Alerted.Things["Stone"])
        {
            ShowAlert("Stone", "경고 메시지 예시!!");
        }
    }
}
