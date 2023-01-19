using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ShadowCoin : Coin
{
  [SerializeField] GameObject shadow;
  [SerializeField] Material mat;
  private void Update() {
    Ray ray = new Ray(transform.position, Vector3.down);
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
      shadow.transform.position = hit.point;
    }
  }
  public override void HitCoin() {
    GameObject player = GameObject.Find("Player");
    player.transform.position = shadow.transform.position + Vector3.up;
    Destroy(this.gameObject);
  }

}
