using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Coin : MonoBehaviour
{
  [SerializeField] float damage;
  [SerializeField] float damageScale;

  public abstract void HitCoin();
  public float GetDamage() {
    return damage;
  }
  public void SetDamage(float d) {
    damage = d;
  }
  public float GetDamageScale() {
    return damageScale;
  }
  public void SetDamageScale(float d) {
    damageScale = d;
  }
}
