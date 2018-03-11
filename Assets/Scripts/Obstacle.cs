using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Obstacle : MonoBehaviour {

	[SerializeField]
	[Range(-5f, 5f)]
	private float m_enterY;
	[SerializeField]
	[Range(1f, 10f)]
	private float m_speed;

	Rigidbody m_rigidbody;

	void OnValidate() {
		Vector3 pos = this.transform.position;
		pos.z = m_enterY;
		this.transform.position = pos;
	}

	void Awake() {
		m_rigidbody = this.GetComponent<Rigidbody>();
	}

	void OnEnable () {
		m_rigidbody.AddForce (new Vector3(-m_speed * 100f, 0, 0));
	}

	void OnDisable () {
		m_rigidbody.velocity = Vector3.zero;
	}
}
