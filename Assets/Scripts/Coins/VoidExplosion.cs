using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidExplosion : MonoBehaviour
{
  float explosionRadius = 1;

  float timer;
  float sqrtTimer;
  public float scale;
  [SerializeField] float explosionTime = 3;

  private void Update() {
    timer += Time.deltaTime;
    //sqrtTimer = Mathf.Sqrt(timer);
    if (timer > explosionTime) {
      Destroy(this.gameObject);
    }
    scale = explosionRadius * ((-1/ Mathf.Pow(explosionTime, 4)) * Mathf.Pow(timer - explosionTime, 4) + 1.0f);
    transform.localScale = new Vector3(scale, scale, scale);
  }
  public void SetExplosionRadius(float radius) {
    explosionRadius = radius;
  }
}
