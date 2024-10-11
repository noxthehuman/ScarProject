using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkill : MonoBehaviour
{
   [SerializeField] private int skill;
   [SerializeField] private bool isPassif;
   private string skillName = "";
   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Player"))
      {
         if (isPassif)
         {
            switch (skill)
            {
               case 1:
                  skillName = "berserker";
                  break;
               case 2:
                  skillName = "rempart";
                  break;
               case 3:
                  skillName = "rewind";
                  break;
            }
         }
         else
         {
            switch (skill)
            {
               case 1:
                  skillName = "tourbilol";
                  break;
               case 2:
                  skillName = "flailAttack";
                  break;
               case 3:
                  skillName = "shieldStun";
                  break;
            }
         }
         GameInfo.passiveSkill = skillName;
      }
   }
}
