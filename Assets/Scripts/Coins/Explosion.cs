using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
  float explosionRadius = 1;
  float damage;

  float timer;
  [SerializeField] float explosionTime;

  private void Update() {
    timer += Time.deltaTime;
    if (timer > explosionTime) {
      Destroy(this.gameObject);
    }
    transform.localScale = new Vector3(explosionRadius * (timer / explosionTime), explosionRadius * (timer / explosionTime), explosionRadius * (timer / explosionTime));
  }
  public void SetExplosionRadius(float radius) {
    explosionRadius = radius;
  }
  public void SetDamage(float d) {
    damage = d;
  }
}
