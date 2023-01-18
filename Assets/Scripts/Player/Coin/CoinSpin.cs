using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpin : MonoBehaviour
{
  Rigidbody rb;
  Vector3 spin;
  [SerializeField] float rpm;

  bool spinning = true;
  void Start() {
    rb = GetComponent<Rigidbody>();
    spin = new Vector3(rpm, 0, 0);
  }

  void FixedUpdate() {
    if (spinning) {
      Quaternion deltaRotation = Quaternion.Euler(spin * Time.fixedDeltaTime);
      rb.MoveRotation(rb.rotation * deltaRotation);
    }
  }
  private void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.tag == "Environment") {
      Destroy(this.gameObject);
    }
  }
}