using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GameInfo : MonoBehaviour
{

    public static float rangedDamage = 35;
    public static float closedDamage = 50;
    public static float shootDelay = 0.2f;
    public static float maxHealthPlayer = 200;
    public static int levelBoss = 0;
    
    //Liste de skills actifs :
    // tourbilol, flailAttack, shieldStun
    public static string activeSkill = "tourbilol";
    public static int activeLevel = 1;
    
    //Liste de skills passifs :
    // berserker, rempart, rewind

    
    public static string passiveSkill = "rewind";
    public static int passiveLevel = 2;
    
    
    /*public static float rangedDamage;
    public static float closedDamage;
    public static float shootDelay;
    public static float maxHealthPlayer;
    public static int levelBoss;
    
    //Liste de skills actifs :
    // tourbilol, flailAttack, shieldStun
    public static string activeSkill;
    public static int activeLevel;
    
    //Liste de skills passifs :
    // berserker, rempart, rewind
    public static string passiveSkill;
    public static int passiveLevel;*/
}