using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveCoin : Coin
{
  [SerializeField] GameObject explosion;

  [SerializeField] float explosionRadius;
  [SerializeField] float explosionRadiusScale;
  public override void HitCoin() {
    GameObject explosionObj = Instantiate(explosion, transform.position, transform.rotation); 
    explosionObj.GetComponent<Explosion>().SetExplosionRadius(explosionRadius * explosionRadiusScale);
    explosionObj.GetComponent<Explosion>().SetDamage(base.GetDamage() * base.GetDamageScale());
    Destroy(this.gameObject);
  }
}
