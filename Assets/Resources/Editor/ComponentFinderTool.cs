using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class ComponentFinderTool : EditorWindow
{
    private List<GameObject> foundObjects = new List<GameObject>();
    private bool autoSelectAll = false;
    private string searchName = "AudioListener";

    [MenuItem("Tools/Component Finder")]
    public static void ShowWindow()
    {
        GetWindow<ComponentFinderTool>("Component Finder");
    }

    private void OnGUI()
    {
        GUILayout.Label("Component Finder Tool", EditorStyles.boldLabel);

        searchName = EditorGUILayout.TextField("Search Component Name:", searchName);

        if (GUILayout.Button("Find Components"))
        {
            FindObjectsByName();
        }

        autoSelectAll = GUILayout.Toggle(autoSelectAll, "Auto-Select All Found Objects");

        if (foundObjects.Count > 0)
        {
            GUILayout.Label($"Found {foundObjects.Count} Object(s) with '{searchName}':", EditorStyles.label);

            if (!autoSelectAll)
            {
                foreach (var obj in foundObjects)
                {
                    if (obj != null)
                    {
                        GUILayout.BeginHorizontal();
                        GUILayout.Label(obj.name);
                        if (GUILayout.Button("Select"))
                        {
                            Selection.activeGameObject = obj;
                        }
                        GUILayout.EndHorizontal();
                    }
                }
            }
            else
            {
                Selection.objects = foundObjects.ToArray();
            }
        }
        else
        {
            GUILayout.Label($"No objects found with component '{searchName}'.", EditorStyles.label);
        }
    }

    private void FindObjectsByName()
    {
        foundObjects.Clear();

        // Знаходимо всі об'єкти за назвою компонента
        var allGameObjects = FindObjectsOfType<GameObject>();
        foreach (var obj in allGameObjects)
        {
            var component = obj.GetComponent(searchName);
            if (component != null)
            {
                foundObjects.Add(obj);
            }
        }

        if (foundObjects.Count > 0)
        {
            Debug.Log($"Found {foundObjects.Count} object(s) with component '{searchName}' on the scene.");
            if (autoSelectAll)
            {
                Selection.objects = foundObjects.ToArray();
            }
        }
        else
        {
            Debug.Log($"No objects found with component '{searchName}' on the scene.");
        }
    }
}
