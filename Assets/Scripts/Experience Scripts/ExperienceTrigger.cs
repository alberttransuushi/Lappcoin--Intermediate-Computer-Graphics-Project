using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceTrigger : MonoBehaviour
{
  float exp;
  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.tag == "Player") {
      other.gameObject.GetComponent<PlayerExperienceTracker>().AddExp(exp);
    }
  }
  public void SetExp(float e) {
    exp = e;
  }
}
