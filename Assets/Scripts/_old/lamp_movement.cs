using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lamp_movement : MonoBehaviour {

    Image IM;
    Color C;
	// Use this for initialization
	void Start () {
        IM = GetComponent<Image>();
        C = IM.color;
        C.a = 0;
	}


     
    float X, Y, a= 0,b = 0, IMalpha = 0;
	// Update is called once per frame
	void Update () {
        a += 0.5f;
        b += 0.25f;
        IMalpha += 0.01f;
        C.a = Mathf.Cos(IMalpha)/2;
        IM.color = C;

        X = transform.position.x + (0.02f * Mathf.Cos(a));
        Y = transform.position.y + (0.01f * Mathf.Sin(b));

        transform.position = new Vector3(X, Y, transform.position.z);
	}
}
