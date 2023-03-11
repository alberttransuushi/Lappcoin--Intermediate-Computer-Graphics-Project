using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceOrb : MonoBehaviour
{
  [SerializeField] ExperienceTrigger trigger;
  float exp;
  public void UpdateExp(float e) {
    trigger.SetExp(exp);
  }
}
