using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box_flow : MonoBehaviour {
    public Rigidbody rb;
    public int force = 5;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.AddForce(new Vector3(-((Screen.width) / 2 - Input.mousePosition.x) / 100, 0, 0) * force);
	}
}
