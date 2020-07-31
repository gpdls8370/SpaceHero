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

    private Animator ballDisappearAni;

    void Start()
    {
        speed = GameManager.ballSpeed;

        BallRb = GetComponent<Rigidbody2D>();
        BallRb.isKinematic = false;
        BallRb.AddForce(new Vector2(0, speed));

        ballDisappearAni = this.gameObject.GetComponent<Animator>();

        sound = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (ballDisappearAni.GetCurrentAnimatorStateInfo(0).length < ballDisappearAni.GetCurrentAnimatorStateInfo(0).normalizedTime)
        {   
            GameObject.Find("GameManager").GetComponent<Life>().minusLife(this.gameObject);
        }
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
            this.transform.Translate(new Vector2(0, -0.05f));
            BallRb.velocity = Vector2.zero;
            ballDisappearAni.enabled = true;
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
