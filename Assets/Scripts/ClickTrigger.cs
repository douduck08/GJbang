using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTrigger : MonoBehaviour {
	
	Camera m_mainCamera;

	void Awake() {
		m_mainCamera = Camera.main;
	}

	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			OnClick ();
		}
	}

	void OnClick () {
		var ray = m_mainCamera.ScreenPointToRay(Input.mousePosition);

		RaycastHit hit = new RaycastHit();
		if (Physics.Raycast (ray, out hit)) {
			Debug.Log(hit.point);
		}
	}
}
