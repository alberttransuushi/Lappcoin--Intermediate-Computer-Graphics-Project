using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningCoin : Coin
{
  [SerializeField] GameObject lightning;
  [SerializeField] private LayerMask layermask;

  Vector3 point;
  private void Update() {
    Ray ray = new Ray(transform.position, Vector3.down);
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
      point = hit.point;
    }
  }
  public override void HitCoin() {
    Instantiate(lightning, point, Quaternion.Euler(Vector3.forward));
    Destroy(this.gameObject);
  }

}
