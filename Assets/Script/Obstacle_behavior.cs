using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_behavior : MonoBehaviour {
    public GameObject obstacle;
	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
        obstacle.transform.position += new Vector3(-0.05f, 0, 0);
      
	}
}
