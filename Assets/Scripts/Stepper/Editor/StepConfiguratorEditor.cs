using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Step))]
public class StepConfiguratorEditor : Editor {
    private Step stepConfigurator;

    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        DrawButton();
    }

    private void DrawButton() {
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Setup")) {
            stepConfigurator.SetupStep();
            SceneView.RepaintAll();
        }
        EditorGUILayout.EndHorizontal();
    }


    void OnEnable() {
        stepConfigurator = (Step)target;
    }
}
