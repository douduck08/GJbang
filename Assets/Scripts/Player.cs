using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class Player : MonoBehaviour {

	[SerializeField]
	[Range(0.1f, 100f)]
	float m_forceFactor;

	Rigidbody m_rigidbody;
	SphereCollider m_collider;
	float m_radius;

	void Awake() {
		m_rigidbody = this.GetComponent<Rigidbody> ();
		m_collider = this.GetComponent<SphereCollider> ();
		m_radius = m_collider.radius;
	}

	public void OnClick (Vector3 pos) {
		Vector2 diff = new Vector2 (pos.x - this.transform.position.x, pos.z - this.transform.position.z);
		Vector2 normalized = diff.normalized;
		float magnitude = diff.magnitude;
		
		if (magnitude < m_radius) {

		} else {
			float force = -m_forceFactor / magnitude;
			m_rigidbody.AddForce (new Vector3 (normalized.x, 0 , normalized.y) * force);
		}
	}
}
