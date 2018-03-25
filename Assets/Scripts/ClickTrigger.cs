using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickTrigger : MonoBehaviour {
	
	[System.Serializable]
 	public class OnClickEvent : UnityEvent<Vector3> { }
	public OnClickEvent onClick;

	Camera m_mainCamera;
	Vector3 m_worldPoint;

	void Awake() {
		m_mainCamera = Camera.main;
	}

	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			m_worldPoint = m_mainCamera.ScreenToWorldPoint(Input.mousePosition);
			onClick.Invoke (m_worldPoint);
		}
	}

	public void Pause () {
		this.enabled = false;
	}

	public void Resume () {
		this.enabled = true;
	}
}
