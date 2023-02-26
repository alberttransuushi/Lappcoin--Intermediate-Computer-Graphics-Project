using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
  [SerializeField] float maxHealth = 10;
  [SerializeField] float health;
  [SerializeField] GameObject healParticles;

  private IEnumerator freeze;

  public RectMask2D healthBar;
  public float maxHealthRectVal = 3;
  public float minHealthRectVal = -200;
  private void Awake() {
    health = maxHealth;
  }
  
  private void Update() {
    UpdateHealthBar();
    if (health <= 0) GetComponent<WinLossMenu>().loss = true;
  }
  void UpdateHealthBar() {
    Vector4 padding = healthBar.padding;
    padding.z = (1 - (health / maxHealth)) * (minHealthRectVal - maxHealthRectVal) + maxHealthRectVal;
    healthBar.padding = padding;
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
  public void Heal(float heal) {
    health += heal;
    StartCoroutine(HealParticlesEnable(1));
    if (health > maxHealth) {
      health = maxHealth;
    }
  }
  private IEnumerator Freeze(float time) {
    PlayerUtility.GetPlayer().GetComponent<LsdShaderTrigger>().TriggerLSD(time);
    EnemyUtility.ToggleFreezeTime();
    yield return new WaitForSeconds(time);
    EnemyUtility.ToggleFreezeTime();
  }
  private IEnumerator HealParticlesEnable(float time) {
    healParticles.SetActive(true);
    yield return new WaitForSeconds(time);
    healParticles.SetActive(false);
  }
  public void TimeFreezeTrigger(float time) {
    freeze = Freeze(time);
    StartCoroutine(freeze);
  }
}
