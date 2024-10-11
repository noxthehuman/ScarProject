using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;

public class RunMapEdited : MonoBehaviour
{
    [SerializeField] private InformationsForEditMap salle1;
    [SerializeField] private InformationsForEditMap salle2; 
    [SerializeField] private InformationsForEditMap salle3; 
    [SerializeField] private InformationsForEditMap salle4; 
    [SerializeField] private InformationsForEditMap salle5; 
    [SerializeField] private InformationsForEditMap salle6; 
    [SerializeField] private InformationsForEditMap salle7; 
    [SerializeField] private InformationsForEditMap salle8; 
    [SerializeField] private InformationsForEditMap salle9; 
    [SerializeField] private InformationsForEditMap salle10; 
    [SerializeField] private InformationsForEditMap salle11; 
    [SerializeField] private InformationsForEditMap salle12; 
    [SerializeField] private InformationsForEditMap salle13; 
    [SerializeField] private InformationsForEditMap salle14; 
    [SerializeField] private InformationsForEditMap salle15; 
    [SerializeField] private InformationsForEditMap typeBoss;
    [SerializeField] private GameObject numberOfSalle;
    private string chemin, jsonString;
    public string scene;

    /* Fonction appeler pour lancer une partie déjà existante */
    public void RunExistantMap() {
        #if UNITY_EDITOR
            string path = EditorUtility.OpenFilePanel("Maps", "", "json");
            if(path != null) {
                jsonString = File.ReadAllText(path);
                InfosForMapEditor nouvelleMap = JsonUtility.FromJson<InfosForMapEditor>(jsonString);
                chemin = Application.streamingAssetsPath + "/EditeurMap.json";
                jsonString = File.ReadAllText(chemin);
                InfosForMapEditor editeur = JsonUtility.FromJson<InfosForMapEditor>(jsonString);
                editeur = nouvelleMap;
                jsonString = JsonUtility.ToJson(editeur);
                File.WriteAllText(chemin, jsonString);
                SceneManager.LoadScene(scene);
            }
        #endif
    }

    /* Fonction appeler pour lancer une nouvelle partie */
    public void RunEditionMap() {
        salle1.GetNumberOfEnemy();
        salle2.GetNumberOfEnemy();
        salle3.GetNumberOfEnemy();
        salle4.GetNumberOfEnemy();
        salle5.GetNumberOfEnemy();
        salle6.GetNumberOfEnemy();
        salle7.GetNumberOfEnemy();
        salle8.GetNumberOfEnemy();
        salle9.GetNumberOfEnemy();
        salle10.GetNumberOfEnemy();
        salle11.GetNumberOfEnemy();
        salle12.GetNumberOfEnemy();
        salle13.GetNumberOfEnemy();
        salle14.GetNumberOfEnemy();
        salle15.GetNumberOfEnemy();
        chemin = Application.streamingAssetsPath + "/EditeurMap.json";
        jsonString = File.ReadAllText(chemin);
        InfosForMapEditor mapEdited = JsonUtility.FromJson<InfosForMapEditor>(jsonString);
        mapEdited.nb_salles = int.Parse(numberOfSalle.GetComponent<TMP_InputField>().text);
        mapEdited.type_boss = typeBoss.typeBoss;
        mapEdited.type_salle_1 = salle1.typeSalle;
        mapEdited.type_habillage_1 = salle1.typeHabillage;
        mapEdited.nb_pit_1 = salle1.numberPit;
        mapEdited.nb_pat_1 = salle1.numberPat;
        mapEdited.nb_pot_1 = salle1.numberPot;
        mapEdited.nb_put_1 = salle1.numberPut;
        mapEdited.type_salle_2 = salle2.typeSalle;
        mapEdited.type_habillage_2 = salle2.typeHabillage;
        mapEdited.nb_pit_2 = salle2.numberPit;
        mapEdited.nb_pat_2 = salle2.numberPat;
        mapEdited.nb_pot_2 = salle2.numberPot;
        mapEdited.nb_put_2 = salle2.numberPut;
        mapEdited.type_salle_3 = salle3.typeSalle;
        mapEdited.type_habillage_3 = salle3.typeHabillage;
        mapEdited.nb_pit_3 = salle3.numberPit;
        mapEdited.nb_pat_3 = salle3.numberPat;
        mapEdited.nb_pot_3 = salle3.numberPot;
        mapEdited.nb_put_3 = salle3.numberPut;
        mapEdited.type_salle_4 = salle4.typeSalle;
        mapEdited.type_habillage_4 = salle4.typeHabillage;
        mapEdited.nb_pit_4 = salle4.numberPit;
        mapEdited.nb_pat_4 = salle4.numberPat;
        mapEdited.nb_pot_4 = salle4.numberPot;
        mapEdited.nb_put_4 = salle4.numberPut;
        mapEdited.type_salle_5 = salle5.typeSalle;
        mapEdited.type_habillage_5 = salle5.typeHabillage;
        mapEdited.nb_pit_5 = salle5.numberPit;
        mapEdited.nb_pat_5 = salle5.numberPat;
        mapEdited.nb_pot_5 = salle5.numberPot;
        mapEdited.nb_put_5 = salle5.numberPut;
        mapEdited.type_salle_6 = salle6.typeSalle;
        mapEdited.type_habillage_6 = salle6.typeHabillage;
        mapEdited.nb_pit_6 = salle6.numberPit;
        mapEdited.nb_pat_6 = salle6.numberPat;
        mapEdited.nb_pot_6 = salle6.numberPot;
        mapEdited.nb_put_6 = salle6.numberPut;
        mapEdited.type_salle_7 = salle7.typeSalle;
        mapEdited.type_habillage_7 = salle7.typeHabillage;
        mapEdited.nb_pit_7 = salle7.numberPit;
        mapEdited.nb_pat_7 = salle7.numberPat;
        mapEdited.nb_pot_7 = salle7.numberPot;
        mapEdited.nb_put_7 = salle7.numberPut;
        mapEdited.type_salle_8 = salle8.typeSalle;
        mapEdited.type_habillage_8 = salle8.typeHabillage;
        mapEdited.nb_pit_8 = salle8.numberPit;
        mapEdited.nb_pat_8 = salle8.numberPat;
        mapEdited.nb_pot_8 = salle8.numberPot;
        mapEdited.nb_put_8 = salle8.numberPut;
        mapEdited.type_salle_9 = salle9.typeSalle;
        mapEdited.type_habillage_9 = salle9.typeHabillage;
        mapEdited.nb_pit_9 = salle9.numberPit;
        mapEdited.nb_pat_9 = salle9.numberPat;
        mapEdited.nb_pot_9 = salle9.numberPot;
        mapEdited.nb_put_9 = salle9.numberPut;
        mapEdited.type_salle_10 = salle10.typeSalle;
        mapEdited.type_habillage_10 = salle10.typeHabillage;
        mapEdited.nb_pit_10 = salle10.numberPit;
        mapEdited.nb_pat_10 = salle10.numberPat;
        mapEdited.nb_pot_10 = salle10.numberPot;
        mapEdited.nb_put_10 = salle10.numberPut;
        mapEdited.type_salle_11 = salle11.typeSalle;
        mapEdited.type_habillage_11 = salle11.typeHabillage;
        mapEdited.nb_pit_11 = salle11.numberPit;
        mapEdited.nb_pat_11 = salle11.numberPat;
        mapEdited.nb_pot_11 = salle11.numberPot;
        mapEdited.nb_put_11 = salle11.numberPut;
        mapEdited.type_salle_12 = salle12.typeSalle;
        mapEdited.type_habillage_12 = salle12.typeHabillage;
        mapEdited.nb_pit_12 = salle12.numberPit;
        mapEdited.nb_pat_12 = salle12.numberPat;
        mapEdited.nb_pot_12 = salle12.numberPot;
        mapEdited.nb_put_12 = salle12.numberPut;
        mapEdited.type_salle_13 = salle13.typeSalle;
        mapEdited.type_habillage_13 = salle13.typeHabillage;
        mapEdited.nb_pit_13 = salle13.numberPit;
        mapEdited.nb_pat_13 = salle13.numberPat;
        mapEdited.nb_pot_13 = salle13.numberPot;
        mapEdited.nb_put_13 = salle13.numberPut;
        mapEdited.type_salle_14 = salle14.typeSalle;
        mapEdited.type_habillage_14 = salle14.typeHabillage;
        mapEdited.nb_pit_14 = salle14.numberPit;
        mapEdited.nb_pat_14 = salle14.numberPat;
        mapEdited.nb_pot_14 = salle14.numberPot;
        mapEdited.nb_put_14 = salle14.numberPut;
        mapEdited.type_salle_15 = salle15.typeSalle;
        mapEdited.type_habillage_15 = salle15.typeHabillage;
        mapEdited.nb_pit_15 = salle15.numberPit;
        mapEdited.nb_pat_15 = salle15.numberPat;
        mapEdited.nb_pot_15 = salle15.numberPot;
        mapEdited.nb_put_15 = salle15.numberPut;
        jsonString = JsonUtility.ToJson(mapEdited);
        File.WriteAllText(chemin, jsonString);
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}