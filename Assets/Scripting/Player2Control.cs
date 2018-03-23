using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Control : MonoBehaviour {

    public GameObject otherPlayer;
    public GameObject ball;
    public float mult=1;
    private float speed;
    public Text countText;
    public Text winText;
    public Text chargeText;
	private Rigidbody rb;
    private Rigidbody oprb;
    private Rigidbody brb;
    private int count;
    public float expFac;
    float moveH;
    float moveV;
    int charge;
    Vector3 startPosition;

    // Use this for initialization
    void Start () {
        count = 0;
        moveH = 0;
        moveV = 0;
        rb = GetComponent<Rigidbody> ();
        oprb = otherPlayer.GetComponent<Rigidbody>();
        brb = ball.GetComponent<Rigidbody>();
        //printScore();
        winText.text = "";
        startPosition = transform.position;
    }

    private void Update()
    {
        if (charge < 100)
        {
            charge = charge + 1;
        }
        if (speed < mult)
        {
            speed = speed + 0.9f;
        }
        printCharge();
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (Input.GetKey("left") == true)
        {
            moveH = -1;
        }
        else if (Input.GetKey("right") == true)
        {
            moveH = 1;
        }
        else
        {
            moveH = 0;
        }

        if (Input.GetKey("down") == true)
        {
            moveV = -1;
        }
        else if (Input.GetKey("up") == true)
        {
            moveV = 1;
        }
        else
        {
            moveV = 0;
        }

        if (Input.GetKeyDown("return") == true)
        {
            if (charge >= 100)
            {
                oprb.AddExplosionForce(5000f, transform.position, 10f, 5f);
                brb.AddExplosionForce(50f, transform.position, 10f, 5f);
                Explode();
                charge = 0;
            }
        }

        Vector3 moveVec = new Vector3(moveH, 0.0f, moveV);
        if (transform.position.y < 1)
        {
            rb.AddForce(speed * moveVec);
        }
        else
        {
            rb.AddForce(speed * moveVec / 3f);
        }

        if (transform.position.y < -2)
        {
            transform.position = startPosition;
            rb.velocity = Vector3.zero;
            speed = 0;
        }
    }

    void printCharge()
    {
        chargeText.fontSize = 8;
        chargeText.fontSize = charge / 4;

        chargeText.text = "Charge: " + charge.ToString();
    }

    void Explode()
    {
        var exp = GetComponent<ParticleSystem>();
        exp.Play();
    }
}
