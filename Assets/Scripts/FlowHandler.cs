using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(PlaneGenerator))]
public class FlowHandler : MonoBehaviour {

	MeshFilter m_meshFilter;
	PlaneGenerator m_planeGenerator;
	List<Color> m_colorList = new List<Color> ();
	
	void Awake() {
		m_meshFilter = GetComponent<MeshFilter> ();
		m_planeGenerator = GetComponent<PlaneGenerator> ();
		
		m_planeGenerator.Generate();
		int vertexCount = m_meshFilter.mesh.vertexCount;
		Vector2 defaultFlow = new Vector2 (0, 1);
		for (int i = 0 ; i < vertexCount; i++) {
			m_colorList.Add (VectorToColor (defaultFlow));
		}
		m_meshFilter.mesh.SetColors(m_colorList);
	}

	Color VectorToColor (Vector2 vec) {
		return new Color (vec.x / 2f + 0.5f, vec.y / 2f + 0.5f, 0);
	}
}
