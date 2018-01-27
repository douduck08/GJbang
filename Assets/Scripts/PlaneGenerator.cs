using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshCollider))]
public class PlaneGenerator : MonoBehaviour {

	MeshFilter m_meshFilter;
	MeshCollider m_meshCollider;

	[SerializeField]
	float m_width = 10f;
	public float width {
		get {
			return m_width;
		}
	}
	[SerializeField]
	float m_height = 10f;
	public float height {
		get {
			return m_height;
		}
	}
	[SerializeField]
	int m_x = 1;
	public int x {
		get {
			return m_x;
		}
	}
	[SerializeField]
	int m_y = 1;
	public int y {
		get {
			return m_y;
		}
	}

	void OnValidate() {
		Generate ();
	}

	public void Generate () {
		Mesh mesh = CreateMesh (m_width, m_height, m_x, m_y);
		m_meshFilter = GetComponent<MeshFilter> ();
		m_meshCollider = GetComponent<MeshCollider> ();
		m_meshFilter.mesh = mesh;
		m_meshCollider.sharedMesh = mesh;
	}

	Mesh CreateMesh (float width, float height, int x, int y) {
		Mesh mesh = new Mesh();
		mesh.name = "ScriptedMesh";

		float deltaPosX = width / x, deltaPosY = height / y;
		float deltaUVX = 1f / x, deltaUVY = 1f / y;
		List<Vector3> verticeList = new List<Vector3> ();
		List<Vector2> uvList = new List<Vector2> ();
		List<int> triangleList = new List<int> ();
		
		for (int i = 0; i < x; i++) {
			for (int j = 0; j < y; j++) {
				verticeList.Add (new Vector3 (-width / 2f + deltaPosX * i, 0.01f, -height / 2f + deltaPosY * j));
				uvList.Add (new Vector2 (deltaUVX * i, deltaUVY * j));

				int index = (y + 1) * i + j;
				triangleList.Add (index);
				triangleList.Add (index + 1);
				triangleList.Add (index + y + 2);
				triangleList.Add (index);
				triangleList.Add (index + y + 2);
				triangleList.Add (index + y + 1);
			}
			verticeList.Add (new Vector3 (-width / 2f + deltaPosX * i, 0.01f, height / 2f));
			uvList.Add (new Vector2 (deltaUVX * i, 1f));
		}
		for (int j = 0; j < y; j++) {
			verticeList.Add (new Vector3 (width / 2f, 0.01f, -height / 2f + deltaPosY * j));
			uvList.Add (new Vector2 (1f, deltaUVY * j));
		}
		verticeList.Add (new Vector3 (width / 2f, 0.01f, height / 2f));
		uvList.Add (new Vector2 (1f, 1f));

		mesh.vertices = verticeList.ToArray ();
		mesh.uv = uvList.ToArray ();
		mesh.triangles = triangleList.ToArray ();
		mesh.RecalculateNormals();
     	return mesh;
	}
}
