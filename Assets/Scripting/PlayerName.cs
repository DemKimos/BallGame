using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerName : MonoBehaviour {

    public GameObject followedPlayer;
    public GameObject otherPlayer;
    public GameObject cam;
    private float xpostxt;
    private float ypostxt;
    private float zpostxt;
    private float xposcam;
    private float yposcam;
    private float zposcam;
    private Transform camTrans;
    private Vector2 newPos;
    public float lgbase;
    RectTransform rt;

    // Use this for initialization
    void Start () {
       //camTrans = cam.GetComponent<camera>();
       // followedTrans = followedPlayer.GetComponent<Transform>;
       // otherTrans = otherPlayer.GetComponent<Transform>;
        rt = GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void Update () {
        xposcam = Mathf.Abs(cam.transform.position.x-followedPlayer.transform.position.x);
        yposcam = followedPlayer.transform.position.y;
        if (followedPlayer.transform.position.z <= otherPlayer.transform.position.z)
        {
            zposcam = -(cam.transform.position.z - followedPlayer.transform.position.z-5);
        }
        else
        {
            zposcam = Mathf.Log(-(cam.transform.position.z - followedPlayer.transform.position.z),lgbase);
        }
        newPos = new Vector2(xposcam,zposcam);
        rt.anchoredPosition = newPos;
	}
}
