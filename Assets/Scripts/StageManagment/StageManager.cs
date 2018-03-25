using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {

	[SerializeField]
	GlobalStageSetting m_globalStageSetting;
	[SerializeField]
	StageSetting[] m_stageSetting;
	[SerializeField]
	GameUIController m_UIController;
	[SerializeField]
	ClickTrigger m_clickTrigger;

	int m_activeStage = 0;
	List<ObstacleBase> m_obstacles = new List<ObstacleBase> ();

	void Start () {
		// TODO: Add opening animate if needed
		m_UIController.onNextClick += OnClickNextBtn;
		m_UIController.SetVisible (false);
		GenerateStage (m_activeStage);
	}

	void OnObstacleEnd (ObstacleBase obstacle) {
		m_obstacles.Remove (obstacle);
		obstacle.DestroyAfterFrames (8);
		if (m_obstacles.Count == 0) {
			OnStageComplete ();
		}
	}

	void OnStageComplete () {
		Debug.LogFormat ("Stage {0}: OnStageComplete", m_activeStage);
		// TODO: Add animate after all obstacle passed, before message UI open
		m_UIController.SetVisible (true);
		m_clickTrigger.Pause ();
	}

	void OnAllStageComplete () {
		Debug.LogFormat ("StageManager: AllStageComplete");
		// TODO: Add final animate, and show final ui, back to menu
	}

	void OnClickNextBtn () {
		// TODO: Add animate when message UI close
		m_UIController.SetVisible (false);
		CheckNextStage ();
	}

	void CheckNextStage () {
		m_activeStage += 1;
		if (m_activeStage < m_stageSetting.Length) {
			GenerateStage (m_activeStage);
			m_clickTrigger.Resume ();
		} else {
			OnAllStageComplete ();
		}
	}

	public void ClearObstacles () {
		foreach (var obstacle in m_obstacles) {
			Destroy (obstacle);
		}
	}

	public void GenerateStage (int index) {
		Debug.LogFormat ("Stage {0}: GenerateStage", m_activeStage);
		foreach (var setting in m_stageSetting[index].obstacleSettings) {
			var obstacle = m_globalStageSetting.InstantiateObstacle (setting.type, this.transform);
			m_obstacles.Add (obstacle);
			obstacle.WriteSetting (setting);
			obstacle.onObstacleEnd += OnObstacleEnd;
		}
		Debug.LogFormat ("Stage {0}: Totally generated {1} obstacles", m_activeStage, m_obstacles.Count);
	}

	public void Pause () {
		for (int i = 0; i < m_obstacles.Count; i++) {
			m_obstacles[i].enabled = false;
		}
	}

	public void Resume () {
		for (int i = 0; i < m_obstacles.Count; i++) {
			m_obstacles[i].enabled = true;
		}
	}
}
