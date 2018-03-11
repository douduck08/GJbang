﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour {
    public GameObject player;
    public float thrust;
    public Rigidbody rb;
    private Vector3 offset;
    
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {//水波漣漪造成移動
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 click = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            offset = click - player.transform.position;
        }

        //rb.AddForce(offset * thrust);
        player.transform.position -= offset/100;
        if(player.transform.position.z >=4.3)
        {
            float z = player.transform.position.z;
            z = 4.3f;


        }
       


    }
}
