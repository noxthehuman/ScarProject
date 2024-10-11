using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PatBehaviour : MonoBehaviour
{
    private GameObject player;
    private float speedMonster = 8;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Deplacement();
        float dist = Vector3.Distance(transform.position, player.transform.position);
        if (dist >= 30)
        {
            speedMonster = 30;
        }

        if (dist <= 10)
        {
            speedMonster = 8;
        }
    }

    private void Deplacement()
    {
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z) - new Vector3(transform.position.x, transform.position.y, transform.position.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3 * Time.deltaTime);
        transform.position += transform.forward * Time.deltaTime * speedMonster;

        if (transform.position.y <= -2)
        {
            Destroy(gameObject);
            if(SceneManager.GetActiveScene().name != "DonjonEditMap") { 
                SpawnEnemy.nbMonster -= 1;
            } else if(SceneManager.GetActiveScene().name == "DonjonEditMap") {
                SpawnEnemyEditMap.nbMonster -= 1;
            }
            if (gameObject.CompareTag("boss"))
            {
                BossBehaviour.isAlive = 0;
            }
        }
    }
}
