using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
  Transform camTrans;
  LayerMask layerMask;
  RaycastHit ray;

  private void Start() {
    camTrans = Camera.main.transform;
  }
  private void Update() {
    if (Input.GetMouseButtonDown(0)) {
      Fire();
    }
  }
  void Fire() {
    Ray ray = new Ray(camTrans.position, camTrans.forward);
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit, 100))
      Debug.DrawLine(ray.origin, hit.point);
  }
}
