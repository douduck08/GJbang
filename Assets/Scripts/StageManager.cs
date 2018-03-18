using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {

	[SerializeField]
	GlobalStageSetting m_globalStageSetting;
	[SerializeField]
	StageSetting[] m_stageSetting;

	[SerializeField]
	List<ObstacleBase> m_obstacles;

	void OnEnable () {
		for (int i = 0; i < m_obstacles.Count; i++) {
			m_obstacles[i].enabled = true;
		}
	}

	void OnDisable () {
		for (int i = 0; i < m_obstacles.Count; i++) {
			m_obstacles[i].enabled = false;
		}
	}

	public void ClearObstacles () {
		foreach (var obstacle in m_obstacles) {
			Destroy (obstacle);
		}
	}

	public void GenerateStage (int index) {
		foreach (var setting in m_stageSetting[index].obstacleSettings) {
			var go = m_globalStageSetting.InstantiateObstacle (setting.type, this.transform);
			go.GetComponent<ObstacleBase> ().WriteSetting (setting);
		}
	}
}
