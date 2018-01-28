using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_behavior : MonoBehaviour {
	void Update () {
        this.transform.position += new Vector3(-0.05f, 0, 0);
	}
}
