using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GlobalStageSetting : ScriptableObject {
	
	[System.Serializable]
	public class ObstaclePrefabDesk {
		public ObstacleType type;
		public ObstacleBase prefab;
	}
	
	public List<ObstaclePrefabDesk> obstaclePrefabDesk;

	public ObstacleBase GetObstaclePrefab (ObstacleType type) {
		var item = obstaclePrefabDesk.FindLast (p => p.type == type);
		if (item == null) {
			throw new System.InvalidOperationException ("Not set prefab for ObstacleType: " + type);
		}
		return item.prefab;
	}

	public ObstacleBase InstantiateObstacle (ObstacleType type, Transform parent) {
		return GameObject.Instantiate<ObstacleBase> (GetObstaclePrefab (type), parent);
	}
}
