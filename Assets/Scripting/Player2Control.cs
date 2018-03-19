using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Control : MonoBehaviour {

	public float mult=1;
    public Text countText;
    public Text winText;
	private Rigidbody rb;
    private int count;
    float moveH;
    float moveV;
    Vector3 startPosition;

    // Use this for initialization
    void Start () {
        count = 0;
        moveH = 0;
        moveV = 0;
        rb = GetComponent<Rigidbody> ();
        printScore();
        winText.text = "";
        startPosition = transform.position;
    }

    private void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate () {
        if (Input.GetKey("a") == true)
        {
            moveH = -1;
        }
        else if(Input.GetKey("d") == true)
        {
            moveH = 1;
        }
        else
        {
            moveH = 0;
        }

        if (Input.GetKey("s") == true)
        {
            moveV = -1;
        }
        else if (Input.GetKey("w") == true)
        {
            moveV = 1;
        }
        else
        {
            moveV = 0;
        }


        Vector3 moveVec = new Vector3(moveH, 0.0f, moveV);
        rb.AddForce(mult*moveVec);
        if (transform.position.y < -2)
        {
            transform.position = startPosition;
            rb.velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            printScore();
        }
    }

    void printScore()
    {
        countText.text = "Score: " + count.ToString();
        if (count == 13)
        {
            winText.text = "YOU WON!";
        }
    }
}
