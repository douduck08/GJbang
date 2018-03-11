using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {


	// Use this for initialization
	void Start () {
     
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Gstart() {
        SceneManager.LoadScene("gameplay");
    }
}
