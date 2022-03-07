using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Entity entity;
    // Start is called before the first frame update

    [Header("Player UI")]
    public Slider health,mana,stamina,xp;
    void Start()
    {
        entity.currentHealth = entity.maxHealth;
        entity.currentMana = entity.maxMana;
        entity.currentStamina = entity.maxStamina;

        health.maxValue = entity.maxHealth;
        mana.maxValue = entity.maxMana;
        stamina.maxValue = entity.maxStamina;

        health.value = entity.maxHealth;
        mana.value = entity.maxMana;
        stamina.value = entity.maxStamina;

        xp.value = 0;
    }
    
    private void Update(){
        health.value = entity.currentHealth;
        mana.value = entity.currentMana;
        stamina.value = entity.currentStamina;
        if(Input.GetKeyDown(KeyCode.Space))
          entity.currentHealth -= 1;
    }

}
