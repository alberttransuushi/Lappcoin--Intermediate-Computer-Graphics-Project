using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeParticle : MonoBehaviour
{
  VolumetricSmokes smokeOrigin;
  int stackPosition;
  bool stackBase;
  float GrowthImportance;

  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.tag == "Environment") {
      stackBase = true;
    }
  }
  public void Grow() {
    //if taller than height limit dont grow upwards
    //if touching ground, dont ground downwards or sideways
    //is surrounded by smokes dont grow in general
  }
}
