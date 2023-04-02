using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeShift : MonoBehaviour
{
  [SerializeField] float timeScale = 1;
  [SerializeField] float loopTime = 1;
  [SerializeField] bool roundToByPI = true;
  [SerializeField] string timeShift = "_TimeShift";
  Material m;
  [SerializeField] float timer;
  private void Start() {
    if (roundToByPI) {
      loopTime = Mathf.RoundToInt(loopTime / (Mathf.PI * 2)) * Mathf.PI * 2;
      
    }
    m = GetComponent<Renderer>().material;
  }
  private void Update() {
    timer += Time.deltaTime;
    if (timer > loopTime) {
      timer -= loopTime;
    }
    m.SetFloat(timeShift, timer / loopTime);
  }
}
