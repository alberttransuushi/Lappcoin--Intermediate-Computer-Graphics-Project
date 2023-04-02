using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
  [SerializeField] float damagePerSecond;
  [SerializeField] List<GameObject> enemies;
  float timer;
  float duration = 3;
  private void Start() {
    Camera.main.GetComponent<CrepuscularRays>().sun = GetComponent<Light>();
    Camera.main.GetComponent<CrepuscularRays>().enabled = true;
  }
  private void Update() {
    timer += Time.deltaTime;
    if (timer > duration) {
      Camera.main.GetComponent<CrepuscularRays>().enabled = false;
      Destroy(this.gameObject);
    }
  }
  public void SetDuration(float time) {
    duration = time;
  }
  private void FixedUpdate() {
    for (int i = 0; i < enemies.Count; i++) {
      enemies[i].GetComponent<BasicEnemyHealth>().health -= damagePerSecond / 60;
    }
  }
  public void SetDamagePerSecond(float dps) {
    damagePerSecond = dps;
  }

}
