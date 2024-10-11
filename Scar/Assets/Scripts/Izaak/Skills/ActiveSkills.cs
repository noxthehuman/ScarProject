using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class ActiveSkills : MonoBehaviour
{
    [SerializeField] private BulletController bullet;
    private int numBullets = 10;
    private float bulletSpeed = 20;
    private float radius = 1;
    
    private void Update()
    {
        switch (GameInfo.activeSkill)
        {
            case "tourbilol":
                Tourbilol();
                break;
            case "flailAttack":
                flailAttack();
                break;
            case "shieldStun":
                shieldStun();
                break;
        }
    }

    private void Tourbilol()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && Mana.currentMana >= 50)
        {
            Mana.currentMana -= 50;
            for (int i = 0; i < numBullets; i++)
            {
                // Determine la position de spawn des balles
                BulletController newBullet = Instantiate(bullet, gameObject.transform.position + Vector3.up * radius, new Quaternion(0, 0, 0, 0)) as BulletController;
                newBullet.speed = bulletSpeed;
                // Modifie la manière de spawn des balles (ici en cercle)
                newBullet.transform.RotateAround(gameObject.transform.position, Vector3.up, 360 / (float)numBullets * i);
            }
        }
    }

    private void flailAttack()
    {
        Debug.Log("FLAIL ATTACK !!!");
        //TODO CODE THIS PART WHEN THE WEAPON IS IMPLEMENTED
    }

    private void shieldStun()
    {
        Debug.Log("SHIELD STUN !!!");
        //TODO CODE THIS PART WHEN THE SHIELD IS IMPLEMENTED
    }
}
