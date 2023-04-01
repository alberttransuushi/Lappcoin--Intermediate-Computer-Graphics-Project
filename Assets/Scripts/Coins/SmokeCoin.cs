using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeCoin : Coin
{
  [SerializeField] GameObject smoke;
  [SerializeField] float duration;

  Vector3 point;
  private void Update() {
    Ray ray = new Ray(transform.position, Vector3.down);
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
      point = hit.point;
    }
  }
  public override void HitCoin() {
    GameObject l = Instantiate(smoke, point, Quaternion.Euler(Vector3.forward));
    l.transform.localScale = Vector3.one * base.GetDamageScale();
    l.GetComponent<VolumetricSmokeFill>().SetDuration(duration);
    Destroy(this.gameObject);
  }
}
