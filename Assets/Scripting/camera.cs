using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;
    //zoom is arbitrary
    public float zoomFac;
    public float minZoom;
    public float smoothness;
    private float camPosX;
    private float playerDist;
    private float lowestZ;
    private Vector3 camPos;
    private float smoother;
    

    // Use this for initialization
    void Start () {

    }

    private void Update()
    {
        
    }

    // Update is called once per frame
    void LateUpdate () {
        playerDist = Vector3.Distance(player1.transform.position, player2.transform.position);
        
        //camPosX is just the middle of the x coordinates of p1 and p2
        camPosX =(player1.transform.position.x + player2.transform.position.x)/2;
        lowestZ=Mathf.Min(player1.transform.position.z, player2.transform.position.z);
        smoother = Mathf.Log((zoomFac), smoothness);
        //log is used to smoothen camera zoom (slow down camera zoom?) (please suggest better functions)
        camPos = new Vector3(camPosX, -smoother*playerDist+minZoom, smoother * playerDist-minZoom+lowestZ);
        transform.position = camPos;
    }
}
