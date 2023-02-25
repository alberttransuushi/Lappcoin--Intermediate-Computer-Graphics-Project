using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyHealth : MonoBehaviour
{
  public float health;
  private void Awake() {
    health = EnemyUtility.GetHealth();
  }
  private void Update() {
    if (health <= 0) {
      Destroy(this.gameObject);
      EnemyUtility.AddEnemy(-1);
      EnemyUtility.AddKills(1);
    }
  }
}
