using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFreezeCoin : Coin
{
  public override void HitCoin() {//damage is time in seconds
    PlayerUtility.GetPlayer().GetComponent<PlayerHealth>().TimeFreezeTrigger(base.GetDamage() * base.GetDamageScale());
    Destroy(this.gameObject);
  }
}
