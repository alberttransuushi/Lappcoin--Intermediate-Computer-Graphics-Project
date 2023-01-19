using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Gun : MonoBehaviour
{
  Transform camTrans;
  [SerializeField] Transform gunTip;
  [SerializeField] Material laserMaterial;
  LayerMask layerMask;
  RaycastHit ray;

  private void Start() {
    camTrans = Camera.main.transform;
    Debug.DrawLine(Vector3.back, Vector3.forward);
  }
  private void Update() {
    if (Input.GetMouseButtonDown(0)) {
      Fire();
    }
  }
  void Fire() {
    Ray ray = new Ray(camTrans.position, camTrans.forward);
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
      DrawLine(ray.origin, hit.point, Color.red, 0.1f, 2f);
      DrawLine(gunTip.transform.position, hit.point, Color.blue, 0.1f, 2f);
      if (hit.collider.gameObject.tag == "Coin") {
        hit.collider.transform.GetComponent<Coin>().HitCoin();
      }
    }

  }
  void DrawLine(Vector3 start, Vector3 end, Color color, float width, float duration) {
    GameObject myLine = new GameObject();
    myLine.transform.position = start;
    myLine.AddComponent<LineRenderer>();
    LineRenderer lr = myLine.GetComponent<LineRenderer>();
    lr.material = laserMaterial;
    lr.startColor = color;
    lr.endColor = color;
    lr.endWidth = width;
    lr.startWidth = width;
    lr.SetPosition(0, start);
    lr.SetPosition(1, end);
    GameObject.Destroy(myLine, duration);
  }

}
