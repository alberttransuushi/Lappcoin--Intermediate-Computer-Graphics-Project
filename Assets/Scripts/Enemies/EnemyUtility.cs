using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyUtility
{
  static int killCount;
  static int enemyCount;
  static int enemyLimit = 3;
  static float enemyHealth = 15;
  static float enemyDamage = 1.5f;
  static bool freeze;
  public static void AddKills(int kills) {
    killCount += kills;
  }
  public static int GetKills() {
    return killCount;
  }
  public static void AddEnemy(int enemies) {
    enemyCount += enemies;
  }
  public static int GetEnemyCount() {
    return enemyCount;
  }
  public static void AddEnemyLimit(int enemies) {
    enemyLimit += enemies;
  }
  public static int GetEnemyLimit() {
    return enemyLimit;
  }
  public static void SetEnemyHealth(int h) {
    enemyHealth = h;
  }
  public static float GetHealth() {
    return enemyHealth;
  }
  public static void IncreaseEnemyDamage(int d) {
    enemyDamage += d;
  }
  public static float GetEnemyDamage() {
    return enemyDamage;
  }
  public static void ToggleFreezeTime() {
    freeze = !freeze;
  }
  public static bool IsEnemyFrozen() {
    return freeze;
  }
}
