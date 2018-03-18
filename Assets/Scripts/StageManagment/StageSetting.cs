using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StageSetting : ScriptableObject {
	public List<ObstacleSetting> obstacleSettings;
	[TextArea(5, 10)]
    public string message;
}
