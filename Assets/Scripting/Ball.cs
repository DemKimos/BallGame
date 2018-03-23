using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    private int lasttouch;
    private int p1score;
    private int p2score;
    public Text textp1;
    public Text textp2;
    private Rigidbody rb;
    Vector3 startPosition;

    // Use this for initialization
    void Start () {
        p1score = 0;
        p2score = 0;
        printScore1();
        printScore2();
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("P1 Goal"))
        {
            p1score = p1score + 1;
            printScore1();
            transform.position = startPosition;
            rb.velocity = Vector3.zero;
        }
        else if (other.gameObject.CompareTag("P2 Goal"))
        {
            p2score = p2score + 1;
            printScore2();
            transform.position = startPosition;
            rb.velocity = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update () {
        
    }

    void printScore1()
    {
        textp1.text = "Score: " + p1score.ToString();
        if (p1score == 5)
        {
           // winText.text = "YOU WON!";
        }
    }

    void printScore2()
    {
        textp2.text = "Score: " + p2score.ToString();
        if (p2score == 5)
        {
            // winText.text = "YOU WON!";
        }
    }
}
