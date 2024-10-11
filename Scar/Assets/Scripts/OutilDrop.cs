using UnityEditor;
using UnityEngine;

#if(UNITY_EDITOR)
public class OutilDrop : EditorWindow
{

    [MenuItem("Custom Tools/ Equilibrage Drop")]
    public static void ShowWindow()
    {
        GetWindow(typeof(OutilDrop));
    }

    private void OnGUI()
    {
        GUILayout.Label("Equilibrage Drop", EditorStyles.boldLabel);

        HealthEnemy.percent_health_potion = EditorGUILayout.FloatField("Percentage Health", HealthEnemy.percent_health_potion);
        HealthEnemy.percent_mana_potion = EditorGUILayout.FloatField("Percentage Mana", HealthEnemy.percent_mana_potion);
        HealthEnemy.percent_damage_potion = EditorGUILayout.FloatField("Percentage Damage", HealthEnemy.percent_damage_potion);
        HealthEnemy.percent_shield_potion = EditorGUILayout.FloatField("Percentage Shield", HealthEnemy.percent_shield_potion);
        HealthEnemy.percent_destruct_potion = EditorGUILayout.FloatField("Percentage Destruct", HealthEnemy.percent_destruct_potion);
        HealthEnemy.percent_coin = EditorGUILayout.FloatField("Percentage Coin", HealthEnemy.percent_coin);
        HealthEnemy.percent_rubis = EditorGUILayout.FloatField("Percentage Rubis", HealthEnemy.percent_rubis);
    }
}

public class Drop : MonoBehaviour
{
    float percentage_health;
    float percent_mana_potion;
    float percent_damage_potion;
    float percent_shield_potion;
    float percent_destruct_potion;
    float percent_coin;
    float percent_rubis;
}
#endif 