using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
  Transform playerTrans;
  public List<GameObject> enemies;
  public float minDistance;
  public float maxDistance;
  bool isActive;
  private void FixedUpdate() {
    float distance = Vector3.Distance(PlayerUtility.GetPlayer().transform.position, transform.position);
    if (distance > minDistance && distance < maxDistance) {
      isActive = true;
    } else {
      isActive = false;
    }
    if (isActive) {
      if (EnemyUtility.GetEnemyCount() < EnemyUtility.GetEnemyLimit() && Random.Range(0,100) < 1) {
        Instantiate(enemies[Random.Range(0, enemies.Count - 1)], transform.position + new Vector3(0, 2, 0), transform.rotation);
        EnemyUtility.AddEnemy(1);
      }
    }
  }
}
