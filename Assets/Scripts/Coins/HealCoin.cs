using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCoin : Coin
{
  public override void HitCoin() {
    PlayerUtility.GetPlayer().GetComponent<PlayerHealth>().Heal(base.GetDamage() * base.GetDamageScale());
    Destroy(this.gameObject);
  }
}
