using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour {

	public event Action onNextClick;

	Canvas m_canvas;
	GraphicRaycaster m_raycaster;
	[SerializeField]
	Text m_messageText;

	void Awake() {
		m_canvas = GetComponent<Canvas> ();
		m_raycaster = GetComponent<GraphicRaycaster> ();
	}

	public void SetVisible (bool value) {
		m_canvas.enabled = value;
		m_raycaster.enabled = value;
	}

	public void OnNextClick () {
		if (onNextClick != null) {
			onNextClick.Invoke ();
		}
	}

	public void SetMessage (string msg) {
		m_messageText.text = msg;
	}
}
