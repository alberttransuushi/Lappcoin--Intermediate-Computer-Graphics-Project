using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Coin
{
  public override void HitCoin() {
    //heal for
    //base.GetDamage() * base.GetDamageScale());
    Destroy(this.gameObject);
  }
}
