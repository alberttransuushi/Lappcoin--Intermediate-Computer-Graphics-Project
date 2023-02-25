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
    GameObject l = Instantiate(lightning,
      point + new Vector3(0, (transform.position.y - point.y)/2,0),
      Quaternion.Euler(Vector3.forward));
    l.transform.localScale = new Vector3(l.transform.localScale.x, (transform.position.y - point.y) / 2, l.transform.localScale.z);
    l.GetComponent<DamageOverTime>().SetDamagePerSecond(base.GetDamage() * base.GetDamageScale());
    Destroy(this.gameObject);
  }

}
