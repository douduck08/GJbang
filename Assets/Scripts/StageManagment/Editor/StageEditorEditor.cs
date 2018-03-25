using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(StageEditor))]
public class StageEditorEditor : Editor {

	public override void OnInspectorGUI () {
        base.OnInspectorGUI ();

        if (GUILayout.Button("Clear Obstacles")) {
            var stageEditor = (StageEditor)this.target;
            stageEditor.ClearObstacles ();
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }

        if (GUILayout.Button("Load Stage Setting")) {
            var stageEditor = (StageEditor)this.target;
            stageEditor.LoadStageSetting ();
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }

        if (GUILayout.Button("Save Stage Setting")) {
            var stageEditor = (StageEditor)this.target;
            stageEditor.SaveStageSetting ();
        }
    }
}