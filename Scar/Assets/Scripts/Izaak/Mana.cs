using UnityEngine.UI;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public Image mana;
    public static float currentMana = 200;
    public static float maxMana = 200;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mana.fillAmount = currentMana / maxMana;
        currentMana += 2 * Time.deltaTime;

        if (currentMana >= 200)
        {
            currentMana = 200;
        }

        if (currentMana <= 0)
        {
            currentMana = 0;
        }
    }
}
