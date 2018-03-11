using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour {

	[SerializeField]
	private Obstacle[] m_obstacles;

	void OnEnable () {
		for (int i = 0; i < m_obstacles.Length; i++) {
			m_obstacles[i].enabled = true;
		}
	}

	void OnDisable () {
		for (int i = 0; i < m_obstacles.Length; i++) {
			m_obstacles[i].enabled = false;
		}
	}
}
