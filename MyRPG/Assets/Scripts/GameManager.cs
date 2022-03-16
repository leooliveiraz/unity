using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public Int32 CalculateHealth(Player player)
  {
    //formula (resistance * 10) - (level + 4) + 10
    Int32 result = (player.entity.resistence * 10) + (player.entity.level + 4) + 10 ;
    Debug.LogFormat("Calculate Health {0} ", result);
    return result;
  }
  public Int32 CalculateMana(Player player)
  {
    //formula (intelligence * 10) - (level + 4) + 10
    Int32 result = (player.entity.intelligence * 10) + (player.entity.level + 4) + 5 ;
    Debug.LogFormat("Calculate Mana {0} ", result);
    return result;
  }

  public Int32 CalculateStamina(Player player)
  {
    //formula (resistance * 10) - (level + 4) + 10
    Int32 result = (player.entity.resistence + player.entity.willpower) + (player.entity.level + 4) + 10 ;
    Debug.LogFormat("Calculate Stamina {0} ", result);
    return result;
  }
  
  public Int32 CalculateDamage(Player player, int weaponDamage)
  {
    //formula (str * 2) + (weapondmg + 2) + (level*3) + rangom(1-20)
    System.Random rnd = new System.Random();
    Int32 result = (player.entity.strength * 2) + (weaponDamage * 2) + (player.entity.level * 3) + (rnd.Next(1,20)) ;
    Debug.LogFormat("Calculate Damage {0} ", result);
    return result;
  }
  public Int32 CalculateDefense(Player player, int armorDefense)
  {
    //formula (endurance * 2) + (level *3) + armorDefense
    Int32 result = (player.entity.resistence * 2)  + (player.entity.level * 3) + armorDefense;
    Debug.LogFormat("Calculate Defense {0} ", result);
    return result;
  }

}
