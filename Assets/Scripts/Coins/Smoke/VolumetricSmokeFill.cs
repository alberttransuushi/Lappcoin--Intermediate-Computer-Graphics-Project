using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumetricSmokeFill : MonoBehaviour
{
  [Header("Size in cubes")]
  [SerializeField] float size;
  [SerializeField] float heightLimit;
  [SerializeField] float cubeSize;
  [SerializeField] float bloomSpeed;
  [SerializeField] GameObject smoke;

  float timer;
  float duration = 3;
  public List<GameObject> smokeParticles;
  int particles;
  private void Start() {
    smokeParticles = new List<GameObject>();
  }
  private void FixedUpdate() {
    particles = 0;
    for (int i = 0; i < smokeParticles.Count; i++) {
      particles += 1;
    }
    if (particles < size) {
      transform.localScale += Vector3.one * bloomSpeed;
      for (int i = smokeParticles.Count - 1; i >= 0; i++) {
        Destroy(smokeParticles[i]);
        smokeParticles.RemoveAt(i);
      }
      int cubelimit = Mathf.RoundToInt(transform.localScale.x / cubeSize);
      for (float i = -(cubeSize * cubelimit); i <= (cubeSize * cubelimit); i += cubeSize) {
        for (float j = -(cubeSize * cubelimit); j <= (cubeSize * cubelimit); j += cubeSize) {
          //for (float k = -(cubeSize * cubelimit); k <= (cubeSize * cubelimit); k += cubeSize) {
            if (Mathf.Sqrt(Mathf.Pow(i, 2) + Mathf.Pow(j, 2)) < transform.localScale.x) {
              GameObject temp = Instantiate(smoke, transform.position + new Vector3(i, 0, j), Quaternion.Euler(0, 0, 0));
              smokeParticles.Add(temp);
              temp.transform.localScale = Vector3.one * cubeSize;
              temp.transform.SetParent(transform);
            }
          //}
        }
      }

    }
  }
  private void Update() {
    //timer += Time.deltaTime;
    if (timer > duration) {
      Destroy(this.gameObject);
    }
  }
  public void SetDuration(float time) {
    duration = time;
  }
}
