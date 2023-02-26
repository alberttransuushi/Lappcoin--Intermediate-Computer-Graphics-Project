using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedSelfDestruct : MonoBehaviour
{
  float timer;
  float duration = 3;
  private void Update() {
    timer += Time.deltaTime;
    if (timer > duration) Destroy(this.gameObject);
  }
  public void SetDuration(float time) {
    duration = time;
  }
}
