using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumetricSmokes : MonoBehaviour
{
  [Header ("Size in cubes")]
  [SerializeField] float size;
  [SerializeField] float heightLimit;
  [SerializeField] float cubeSize;
  [SerializeField] float bloomSpeed;

  float timer;
  List<SmokeCoin> smokeParticles;
  int particles;

  private void Update() {
    particles = 0;
    for (int i = 0; i < smokeParticles.Count; i++) {
      //if (smokeParticles[i].GetComponent<SmokeParticle>().GetActive()) particles++;
    }
    if (particles < size) {
      transform.localScale += Vector3.one * bloomSpeed;

    }
  }
  public bool ReturnExpansion() {
    if (size > smokeParticles.Count) return true;
    return false;
  }
}

