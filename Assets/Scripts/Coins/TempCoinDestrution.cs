using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempCoinDestrution : Coin
{
  public override void HitCoin() {
    Destroy(this.gameObject);
  }
}
