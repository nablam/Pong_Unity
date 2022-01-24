using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    //1152*864  or 960*600
     float speed = 3.0f;
    Rigidbody rb;
    Vector3 _curDirection;
    // Start is called before the first frame update
    int hitcount=0;
    public TestHid theGame;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //_curDirection = Vector3.one.normalized;
        _curDirection = new Vector3(1.0f, 1.0f, 0.0f).normalized;
    }

    private void FixedUpdate()
    {
        rb.velocity = _curDirection * speed;
    }
    // Update is called once per frame

    private void OnCollisionEnter(Collision collision)
    {
        hitcount++;

        if (hitcount % 6 == 0) {
            speed += 0.2f;
        }

        Vector2 direction = collision.GetContact(0).normal;
        if (direction.x == 1)
        {// print("right");
            _curDirection.x = 1.0f;
        }
        if (direction.x == -1)
        {// print("left");
            _curDirection.x = -1.0f;
        }
        if (direction.y == 1)
        {//print("up");
            _curDirection.y = 1.0f;
        }
        if (direction.y == -1)
        {//print("down");
            _curDirection.y = -1.0f;
        }


        if (collision.gameObject.CompareTag("P1wall")) { theGame.increaseP1(); theGame.resetBAll(); }
        if (collision.gameObject.CompareTag("P2wall")) { theGame.increaseP2(); theGame.resetBAll(); }
    }
}
