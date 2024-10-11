using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTentacule : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        Destroy(gameObject, 2);
    }
}
