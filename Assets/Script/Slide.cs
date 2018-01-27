using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour {
    private Vector3 offset,p1,p2;
    public bool slide;
    public GameObject player;
    public Rigidbody rb;



    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {//滑動造成水燈移動
        if (Input.GetMouseButtonDown(0))
        {
            
            Vector2 p1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 p2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            offset = p2 - p1;
            rb.AddForce(offset*5);
            //player.transform.position += offset / 10;



        }
    }
}
