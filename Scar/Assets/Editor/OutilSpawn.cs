using UnityEditor;
using UnityEngine;

public class OutilSpawn : EditorWindow
{
    [MenuItem("Custom Tools/ Equilibrage Spawn Ennemis")]
    public static void ShowWindow()
    {
        GetWindow(typeof(OutilSpawn));
    }

    private void OnGUI()
    {
        GUILayout.Label("Equilibrage Spawn Ennemis", EditorStyles.boldLabel);

        SpawnEnemy.numPat = EditorGUILayout.IntField("Araignées", SpawnEnemy.numPat);
        SpawnEnemy.numPit = EditorGUILayout.IntField("Piraplantes", SpawnEnemy.numPit);
        SpawnEnemy.numPot = EditorGUILayout.IntField("Pierres", SpawnEnemy.numPot);
        SpawnEnemy.numPut = EditorGUILayout.IntField("Raies", SpawnEnemy.numPut);
    }

}

public class Spawn : MonoBehaviour
{
    float numpat;
    float numPit;
    float numPot;
    float numPut;
}
