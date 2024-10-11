using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZoneController : MonoBehaviour
{
    private void Update()
    {
        Destroy(gameObject, 1);
    }
}
