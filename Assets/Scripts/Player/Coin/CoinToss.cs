using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinToss : MonoBehaviour
{
  GameObject coin;
  Rigidbody coinRB;
  GameObject coinHolder;
  CoinBag queue;

  [SerializeField] GameObject coinTarget;
  [SerializeField] float baseCoinForce;

  bool coinCharging;
  float coinCharge;
  public float minCharge;
  public float maxCharge;

  Transform cameraTransform;
  private void Start() {
    cameraTransform = Camera.main.transform;
    queue = GetComponent<CoinBag>();
    coinHolder = transform.GetChild(0).transform.GetChild(0).transform.gameObject;
    coin = transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.gameObject;
    coinRB = coin.transform.GetComponent<Rigidbody>();
  }
  private void Update() {
    if (Input.GetMouseButton(1)) {
      coinCharging = true;
      coinCharge += Time.deltaTime;
      if (coinCharge > maxCharge) {
        coinCharge = maxCharge;
      }
      //Vector3 temp = new Vector3(coinHolder.transform.localPosition.x, -0.5f - ((coinCharge / maxCharge) / 10), coinHolder.transform.localPosition.y);
      //coinHolder.transform.localPosition = temp;
    } else if (coinCharging) {
      Toss(coinCharge + minCharge);
      coinCharging = false;
      coinCharge = 0;
      //coinHolder.transform.localPosition = new Vector3(coinHolder.transform.localPosition.x, -0.5f, coinHolder.transform.localPosition.y);
    }
  }
  void Toss(float power) {
    coin.transform.parent = null;
    coinRB.freezeRotation = false;
    coinRB.constraints = 0;
    Vector3 dir = coinTarget.transform.position - cameraTransform.position;
    coinRB.AddForce(dir.normalized * power * baseCoinForce);
    coin.gameObject.GetComponent<MeshCollider>().enabled = true;
    coin.gameObject.GetComponent<CoinSpin>().enabled = true;
    coin = Instantiate(queue.NewCoin(), coinHolder.transform);
    coinRB = coin.transform.GetComponent<Rigidbody>();
    //Vector3 spinPerSecond = new Vector3(0, 0, 90);
    //Quaternion deltaRotation = Quaternion.Euler(spinPerSecond * Time.fixedDeltaTime);
    //coinRB.MoveRotation(coinRB.rotation * deltaRotation);
    //coin.
  }
}
