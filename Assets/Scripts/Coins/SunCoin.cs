using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunCoin : Coin
{
  [SerializeField] GameObject sun;
  [SerializeField] float duration;

  [SerializeField] float sunRadius;
  [SerializeField] float sunRadiusScale;
  public override void HitCoin() {
    GameObject s = Instantiate(sun, transform.position, Quaternion.Euler(0,90,0));
    s.transform.localScale = Vector3.one * sunRadius* sunRadiusScale;
    s.GetComponent<Sun>().SetDamagePerSecond(base.GetDamage() * base.GetDamageScale());
    s.GetComponent<Sun>().SetDuration(duration);

    Destroy(this.gameObject);
  }
}
