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
  [SerializeField] List<GameObject> enemiesInVoid;

  private void Update() {
    timer += Time.deltaTime;
    //sqrtTimer = Mathf.Sqrt(timer);
    if (timer > explosionTime) {
      for (int i = 0; i < enemiesInVoid.Count; i++) {
        enemiesInVoid[i].GetComponent<BasicEnemyHealth>().health -= 1000000000000000000000f;
      }
      Destroy(this.gameObject);
    }
    scale = explosionRadius * ((-1/ Mathf.Pow(explosionTime, 4)) * Mathf.Pow(timer - explosionTime, 4) + 1.0f);
    transform.localScale = new Vector3(scale, scale, scale);
  }
  public void SetExplosionRadius(float radius) {
    explosionRadius = radius;
  }
  private void OnTriggerEnter(Collider other) {
    if (other.tag == "Enemy") {
      enemiesInVoid.Add(other.gameObject);
    }
  }
  private void OnTriggerExit(Collider other) {
    if (other.tag == "Enemy") {
      enemiesInVoid.Remove(other.gameObject);
    }
  }
}
