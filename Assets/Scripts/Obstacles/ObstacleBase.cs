using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[DisallowMultipleComponent]
public abstract class ObstacleBase : MonoBehaviour {

	public Action<ObstacleBase> onObstacleEnd;
	
	bool m_arriveEnd;
	Rigidbody m_rigidbody;

	protected Rigidbody GetRigidbody () {
		if (m_rigidbody == null) {
			m_rigidbody = GetComponent<Rigidbody> ();
		}
		return m_rigidbody;
	}

	protected void ArriveEndPoint () {
		if (!m_arriveEnd && onObstacleEnd != null) {
			onObstacleEnd.Invoke (this);
		}
		m_arriveEnd = true;
		this.enabled = false;
	}

	public abstract void WriteSetting (ObstacleSetting setting);
	public abstract ObstacleSetting ReadSetting ();

	public void DestroyInEditor () {
		if (!Application.isEditor || Application.isPlaying) {
			throw new System.InvalidOperationException ("DestroyInEditor() is usedd in Edit mode");
		}
		StartCoroutine (DelayDestroy(0));
	}

	public void DestroyAfterFrames (int frames = 0) {
		StartCoroutine (DelayDestroy(frames));
	}

	IEnumerator DelayDestroy (int frames) {
		for (int i = 0; i < frames; i++) {
			yield return new WaitForEndOfFrame();
		}

		if (Application.isEditor) {
			DestroyImmediate (this.gameObject);
		} else {
			Destroy (this.gameObject);
		}
	}
}
