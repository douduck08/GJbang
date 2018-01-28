using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTrigger : MonoBehaviour {
	
	FlowHandler flow;

	void Awake() {
		flow = GetComponent <FlowHandler> ();
	}

	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			flow.OnClick ();
		}
	}
}
