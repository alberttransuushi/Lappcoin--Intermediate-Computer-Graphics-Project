using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : MonoBehaviour
{
  [SerializeField] float damagePerSecond;
  [SerializeField] List<GameObject> enemiesIn;
  private void FixedUpdate() {
    for (int i = 0; i < enemiesIn.Count; i++) {
      enemiesIn[i].GetComponent<BasicEnemyHealth>().health -= damagePerSecond/60;
    }
  }
  private void OnTriggerEnter(Collider other) {
    if (other.tag == "Enemy") {
      enemiesIn.Add(other.gameObject);
    }
  }
  private void OnTriggerExit(Collider other) {
    if (other.tag == "Enemy") {
      enemiesIn.Remove(other.gameObject);
    }
  }
  public void SetDamagePerSecond(float dps) {
    damagePerSecond = dps;
  }
}
