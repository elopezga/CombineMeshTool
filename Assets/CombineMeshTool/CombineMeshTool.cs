using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class CombineMeshTool
{
    [MenuItem("GameObject/CombineMeshTool/Combine Meshes", false, 0)]
    private static void CombineMeshes()
    {
        // ~~~ Preamble ~~~
        // 1. Right-click on gameobject that contains all meshes you want to combine
        // 2. Make prefab copy of original gameobject with seperate meshes
        // 3. Create new gameobject with combined meshes; delete the original from scene

        Debug.LogError("Aye");
        if (!Selection.activeTransform)
        {
            Debug.LogError("You did not select a gameobject");
            return;
        }

        MeshFilter[] meshFilters = GetAllMeshFiltersInChildren(Selection.activeGameObject);
        CombineInstance[] combine = CreateCombineInstances(meshFilters);

        // Create gameobject that will house the combined mesh
        GameObject instanceGameObject = new GameObject("Combined");

    }

    private static MeshFilter[] GetAllMeshFiltersInChildren(GameObject parent)
    {
        MeshFilter[] meshFilters = parent.GetComponentsInChildren<MeshFilter>();

        return meshFilters;
    }

    private static CombineInstance[] CreateCombineInstances(MeshFilter[] meshFilters)
    {
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        for (int i = 0; i < meshFilters.Length; i += 1)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
        }

        return combine;
    }
}
