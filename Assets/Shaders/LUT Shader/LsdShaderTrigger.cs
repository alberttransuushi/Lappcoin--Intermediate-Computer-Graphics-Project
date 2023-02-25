using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LsdShaderTrigger : MonoBehaviour
{
  float timer;
  [SerializeField] float scaleUpTime = 1;
  [SerializeField] float upTime = 1;
  [SerializeField] float scaleDownTime = 1;
  bool triggered;
  bool scaleUp;
  bool isUp;
  bool scaleDown;
  public Material material;
  bool freeze;
  private void Update() {
    if (freeze && !triggered) {
      triggered = true;
      scaleUp = true;
      timer = 0;
    }
    if (triggered) {
      timer += Time.deltaTime;
    } else {
      material.SetFloat("_Contribution", 0f);
    }
    if (timer > scaleUpTime && scaleUp && triggered) {
      timer = 0;
      scaleUp = false;
      isUp = true;
    }
    if (timer > upTime && isUp && triggered) {
      timer = 0;
      isUp = false;
      scaleDown = true;
    }
    if (timer > scaleDownTime && scaleDown && triggered) {
      timer = 0;
      scaleDown = false;
      triggered = false;
      freeze = false;
    }
    if (scaleUp) {
      material.SetFloat("_Contribution", timer / scaleUpTime);
    }
    if (isUp) {
      material.SetFloat("_Contribution", 1f);
    }
    if (scaleDown) {
      material.SetFloat("_Contribution", (scaleDownTime - timer) / scaleDownTime);
    }
  }
  public void TriggerLSD(float time) {
    freeze = true;
    upTime = time - 2;
  }
}
