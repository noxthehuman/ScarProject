using UnityEngine;

public class SwitchCartes : MonoBehaviour
{
    [SerializeField] public GameObject Shield2;
    [SerializeField] public GameObject Shield1;

    public Transform spawnShieldInv;
    public Transform spawnShieldHot;
    public void SwitchShield()
    {
        Destroy(spawnShieldInv.GetChild(0));
        Instantiate<GameObject>(Shield1, spawnShieldInv);
        Destroy(spawnShieldHot.GetChild(0));
        Instantiate<GameObject>(Shield2, spawnShieldHot);
    }

    void Update()
    {
        
    }
}
