using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidCoin : Coin
{
  [SerializeField] GameObject explosion;

  [SerializeField] float explosionRadius;
  [SerializeField] float explosionRadiusScale;
  public override void HitCoin() {
    GameObject explosionObj = Instantiate(explosion, transform.position, transform.rotation);
    explosionObj.GetComponent<VoidExplosion>().SetExplosionRadius(explosionRadius * explosionRadiusScale);
    Destroy(this.gameObject);
  }
}
