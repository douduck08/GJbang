using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshCollider))]
public class FlowHandler : MonoBehaviour {

	[SerializeField]
	PlaneGenerator m_planeGenerator;
	
	void OnValidate() {
		m_planeGenerator.Generate(this.transform, VectorToColor (new Vector2 (0, 1)));
	}

	void Awake() {
		m_planeGenerator.Generate(this.transform, VectorToColor (new Vector2 (0, 1)));
	}

	Color VectorToColor (Vector2 vec) {
		return new Color (vec.x / 2f + 0.5f, vec.y / 2f + 0.5f, 0);
	}

	public void OnClick () {
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		RaycastHit hit = new RaycastHit();
		if (Physics.Raycast (ray, out hit)) {
			AddRipple (hit.point, hit.triangleIndex);
		}
	}

	void AddRipple (Vector3 hitPoint, int triangleIndex) {
		int index;
		index = m_planeGenerator.triangleList[triangleIndex * 3];
		Timing.RunCoroutine (Ripple (index, m_planeGenerator.verticeList[index] - hitPoint));
		index = m_planeGenerator.triangleList[triangleIndex * 3 + 1];
		Timing.RunCoroutine (Ripple (index, m_planeGenerator.verticeList[index] - hitPoint));
		index = m_planeGenerator.triangleList[triangleIndex * 3 + 2];
		Timing.RunCoroutine (Ripple (index, m_planeGenerator.verticeList[index] - hitPoint));
	}

	IEnumerator<float> Ripple (int index, Vector2 flow) {
		float timer = 0f, durability = 0.5f;
		while (timer < durability) {
			SetFlow (index, Vector2.Lerp (flow, new Vector2 (0, 1), timer / durability));
			UpdateMesh ();

			yield return 0f;
			timer += Time.deltaTime;
		}
	}

	void SetFlow (int index, Vector2 vec) {
		m_planeGenerator.colorList[index] = VectorToColor (vec);
	}

	void UpdateMesh () {
		m_planeGenerator.SetColor ();
	}
}
