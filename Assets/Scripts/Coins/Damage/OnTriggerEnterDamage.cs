using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterDamage : MonoBehaviour
{
  public float damage;
  private void OnTriggerEnter(Collider other) {
    if (other.tag == "Enemy") other.GetComponent<BasicEnemyHealth>().health -= damage;
  }
}
