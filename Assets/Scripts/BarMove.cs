using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarMove : MonoBehaviour
{
    public float speed;
    public int bounceDegree;

    public bool leftWallCol;
    public bool rightWallCol;

    private float initSpeed;

    public float ballSpeed;
    private float xForce, yForce;

    private float gap;
    private Rigidbody2D ballRb;

    private Animator playerAni;
    private SpriteRenderer playerSpr;
    private Sprite playerInitialSprite;

    void Start()
    {
        speed = GameManager.barSpeed;
        ballSpeed = GameObject.Find("Ball").GetComponent<BallMove>().speed;
        initSpeed = speed;
        leftWallCol = false;
        rightWallCol = false;
        playerAni = GameObject.Find("Player").GetComponent<Animator>();
        playerSpr = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        playerInitialSprite = playerSpr.sprite;
    }

    void Update()
    {
        barMovement();
    }

    private void barMovement()
    {
        if (Input.GetKey(KeySetting.keys[KeyAction.LEFT]) && !leftWallCol && !Input.GetKey(KeySetting.keys[KeyAction.RIGHT]))
        {
            playerAni.enabled = true;
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeySetting.keys[KeyAction.RIGHT]) && !rightWallCol && !Input.GetKey(KeySetting.keys[KeyAction.LEFT]))
        {
            playerAni.enabled = true;
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            playerSpr.sprite = playerInitialSprite;
            playerAni.enabled = false;
        }
        if (Input.GetKeyDown(KeySetting.keys[KeyAction.BOOST]))
        {
            KeyDown_L(true);
        }
        if (Input.GetKeyUp(KeySetting.keys[KeyAction.BOOST]))
        {
            KeyDown_L(false);
        }
    }

    private void KeyDown_L(bool boostOn)
    {
        if (boostOn)
        {
            speed = initSpeed * 2.2f;
        }
        else
        {
            speed = initSpeed;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        ballRb = collision.gameObject.GetComponent<Rigidbody2D>();

        //막대가 공이랑 부딪히면
        if (collision.gameObject.tag == "Ball")
        {
            if (GameManager.ballisIceTraped == true)
            {
                GameManager.ballisIceTraped = false;
            }

            ballRb.isKinematic = false;
            ballRb.gravityScale = 0;

            Vector2 hitpoint = collision.contacts[0].point;
            Vector2 barCenterPoint = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);

            //공 충돌지점 - 바 중간 == gap (중간부터 얼마나 멀리에서 충돌했는지)
            gap =  hitpoint.x - barCenterPoint.x;

            ballRb.velocity = Vector2.zero;
            //ballRb.AddForce(new Vector2(gap * bounceDegree , ballSpeed);
            
            xForce = gap * bounceDegree;
            if (Mathf.Abs(xForce) > ballSpeed)
            {
                yForce = 40;
            }
            else
            {
                yForce = Mathf.Sqrt(Mathf.Pow(ballSpeed, 2) - Mathf.Pow(gap * bounceDegree, 2));
            }
            
            ballRb.AddForce(new Vector2(xForce , yForce));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "LeftWall_Trigger")
        {
            leftWallCol = true;
        }
        else if (collision.gameObject.name == "RightWall_Trigger")
        {
            rightWallCol = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "WallTrigger")
        {
           leftWallCol = false;
           rightWallCol = false;
        }
    }

}
