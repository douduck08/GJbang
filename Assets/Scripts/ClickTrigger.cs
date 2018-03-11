using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTrigger : MonoBehaviour {
	
	//FlowHandler flow;
	Player m_player;

	void Awake() {
		//flow = GetComponent <FlowHandler> ();
		m_player = GetComponent <Player> ();
	}

	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			//flow.OnClick ();
			m_player.OnClick (Camera.main.ScreenToWorldPoint(Input.mousePosition));
		}
	}
}
