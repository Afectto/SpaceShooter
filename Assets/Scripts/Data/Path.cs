using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Path", menuName = "SO/Path")]
public class Path : ScriptableObject
{
    public List<Vector2> Points = new List<Vector2>();
#if UNITY_EDITOR
    
    [ContextMenu("Save Path")]
    private void SavePoints()
    {
        var enemyPath = FindObjectOfType<ScenePath>();
        if (enemyPath)
        {
            Points = enemyPath.GetPathPoints();
            UnityEditor.EditorUtility.SetDirty(this);
            UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
        }
    }

    [ContextMenu("Load Path")]
    private void LoadPath()
    {
        GameObject path = new GameObject("Path");
        ScenePath scenePath = path.AddComponent<ScenePath>();
        for (int i = 0; i < Points.Count; i++)
        {
            GameObject point = new GameObject($"Point{i}");
            point.transform.SetParent(path.transform);
            point.transform.position = Points[i];
            scenePath.AddPoint(point.transform);
        }
    }
#endif
}
