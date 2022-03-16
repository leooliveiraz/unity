using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Player : MonoBehaviour
{
  public Entity entity;
  // Start is called before the first frame update

  [Header("Player Regen System")]
  public bool regenHPEnabled = true;
  public float regenHPTime = 5f;
  public int regenHPValue = 5;
  public bool regenMPEnabled = true;
  public float regenMPTime = 10f;
  public int regenMPValue = 3;

  [Header("Game Manager")]
  public GameManager manager;

  [Header("Player UI")]
  public Slider health, mana, stamina, xp;
  void Start()
  {
    if (manager == null)
    {
      Debug.LogError("Você precisa anexar o game manager aqui no player");
      return;
    }

    entity.maxHealth = manager.CalculateHealth(this);
    entity.maxMana = manager.CalculateMana(this);
    entity.maxStamina = manager.CalculateStamina(this);

    int damage = manager.CalculateDamage(this, 10); //ser usado no player
    int defense = manager.CalculateDefense(this, 5); // ser usado no inimigo

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

    StartCoroutine(RegenHealth());
    StartCoroutine(RegenMana());
  }

  private void Update()
  {
    health.value = entity.currentHealth;
    mana.value = entity.currentMana;
    stamina.value = entity.currentStamina;
    if (Input.GetKeyDown(KeyCode.Space))
      entity.currentHealth -= 3;
  }

  IEnumerator RegenHealth()
  {
    while (true)
    {
      if (this.regenHPEnabled)
      {
        if (entity.currentHealth < entity.maxHealth)
        {
          Debug.LogFormat("Recuperando HP do jogador");
          entity.currentHealth += this.regenHPValue;
          yield return new WaitForSeconds(this.regenHPTime);
        } else {
        yield return null;
      }
      } else {
        yield return null;
      }
    }
  }
  IEnumerator RegenMana()
  {
    while (true)
    {
      if (this.regenMPEnabled)
      {
        if (entity.currentMana < entity.maxMana)
        {
          Debug.LogFormat("Recuperando MP do jogador");
          entity.currentMana += this.regenMPValue;
          yield return new WaitForSeconds(this.regenMPTime);
        } else {
        yield return null;
      }
      } else {
        yield return null;
      }
    }
  }

}
