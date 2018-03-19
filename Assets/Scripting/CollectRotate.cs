using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectRotate : MonoBehaviour {

    Vector3 startPosition;
    Rigidbody rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (transform.position.y < -2)
        {
            transform.position = startPosition;
            rb.velocity = Vector3.zero;
        }
    }
}
