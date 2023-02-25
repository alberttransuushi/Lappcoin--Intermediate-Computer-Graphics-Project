using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
  [SerializeField] float maxHealth = 10;
  float health;
  private IEnumerator freeze;
  private void Awake() {
    health = maxHealth;
  }
  public void Heal(float heal) {
    health += heal;
    if(health > maxHealth) {
      health = maxHealth;
    }
  }
  public void Damage(float damage) {
    health -= damage;
    if (health < 0) {
      GetComponent<WinLossMenu>().loss = true;
    } else {
      freeze = Freeze(3);
      StartCoroutine(freeze);
    }
  }
  private IEnumerator Freeze(float time) {
    PlayerUtility.GetPlayer().GetComponent<LsdShaderTrigger>().TriggerLSD(time);
    EnemyUtility.ToggleFreezeTime();
    yield return new WaitForSeconds(time);
    EnemyUtility.ToggleFreezeTime();
  }
  public void TimeFreezeTrigger(float time) {
    freeze = Freeze(time);
    StartCoroutine(freeze);
  }
}
