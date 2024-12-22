using UnityEditor;
using UnityEngine;

// Custom Inspector for AvatarEditor
[CustomEditor(typeof(AvatarEditor))]
public class AvatarEditorInspector : Editor
{
    public override void OnInspectorGUI()
    {
        // 기본 Inspector 표시
        DrawDefaultInspector();

        // AvatarEditor 참조
        AvatarEditor editor = (AvatarEditor)target;

        // Apply 버튼 추가
        if (GUILayout.Button("Apply Avatar Changes"))
        {
            editor.ModifyAvatar();
            Debug.Log("Avatar has been modified.");
        }
    }
}