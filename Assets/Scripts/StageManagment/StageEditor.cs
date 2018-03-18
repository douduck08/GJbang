using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StageEditor : MonoBehaviour {

	[SerializeField]
	GlobalStageSetting m_globalStageSetting;
	[SerializeField]
	StageSetting m_stageSetting;
	[SerializeField]
	[TextArea(5, 10)]
    string m_message;
	
	public void ClearObstacles () {
		ObstacleBase[] obstacleList = this.GetComponentsInChildren<ObstacleBase> ();
		foreach (var obstacle in obstacleList) {
			obstacle.DestroyInEditor ();
		}
	}

	public void LoadStageSetting () {
		Assert ();
		ClearObstacles ();

		foreach (var setting in m_stageSetting.obstacleSettings) {
			var go = m_globalStageSetting.InstantiateObstacle (setting.type, this.transform);
			go.GetComponent<ObstacleBase> ().WriteSetting (setting);
		}
	}

	public void SaveStageSetting () {
		Assert ();

		ObstacleBase[] obstacleList = this.GetComponentsInChildren<ObstacleBase> ();
		m_stageSetting.obstacleSettings = obstacleList.Select(p => p.ReadSetting()).ToList ();
		m_stageSetting.message = m_message;
	}

	void Assert () {
		if (m_globalStageSetting == null) {
			throw new System.NullReferenceException ("globalStageSetting not set");
		}
		if (m_stageSetting == null) {
			throw new System.NullReferenceException ("stageSetting not set");
		}
	}
}
