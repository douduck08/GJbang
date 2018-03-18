using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SphereObstacle : ObstacleBase {

	[SerializeField]
	[Range(-5f, 5f)]
	private float m_enterPoint;
	[SerializeField]
	[Range(1f, 10f)]
	private float m_speed;
	[SerializeField]
	private float m_time;

	void OnValidate() {
		Vector3 pos = base.transform.position;
		pos.z = m_enterPoint;
		pos.x = 10f + m_time * m_speed;
		base.transform.position = pos;
	}

	void OnEnable () {
		rigidbody.AddForce (new Vector3(-m_speed * rigidbody.mass * 100f, 0, 0));
	}

	void OnDisable () {
		rigidbody.velocity = Vector3.zero;
	}

    public override void WriteSetting (ObstacleSetting setting) {
		m_enterPoint = setting.detailData[0];
		m_speed = setting.detailData[1];
		m_time = setting.detailData[2];
        OnValidate ();
    }

    public override ObstacleSetting ReadSetting () {
		ObstacleSetting setting;
		setting.type = ObstacleType.Sphere;
		setting.detailData = new float[] { m_enterPoint, m_speed, m_time };
        return setting;
    }
}
