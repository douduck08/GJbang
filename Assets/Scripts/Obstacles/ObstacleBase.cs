using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[DisallowMultipleComponent]
public abstract class ObstacleBase : MonoBehaviour {

	Rigidbody m_rigidbody;
	protected Rigidbody rigidbody {
		get {
			if (m_rigidbody == null) {
				m_rigidbody = GetComponent<Rigidbody> ();
			}
			return m_rigidbody;
		}
	}

	public abstract void WriteSetting (ObstacleSetting setting);
	public abstract ObstacleSetting ReadSetting ();

	public void DestroyInEditor () {
		if (!Application.isEditor || Application.isPlaying) {
			throw new System.InvalidOperationException ("DestroyInEditor() is usedd in Edit mode");
		}
		StartCoroutine (DelayDestroy());
	}

	IEnumerator DelayDestroy () {
		yield return new WaitForEndOfFrame();
		DestroyImmediate (this.gameObject);
	}
}
