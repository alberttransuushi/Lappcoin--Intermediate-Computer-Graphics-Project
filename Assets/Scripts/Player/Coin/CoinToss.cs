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
  [SerializeField] float timeForceScale;
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
    coin = Instantiate(queue.NewCoin(), coinHolder.transform);
    coinRB = coin.transform.GetComponent<Rigidbody>();
  }
  private void Update() {
    if (Input.GetMouseButton(1)) {
      coinCharging = true;
      coinCharge += Time.deltaTime;
      if (coinCharge > maxCharge) {
        coinCharge = maxCharge;
      }

    } else if (coinCharging) {
      Toss(coinCharge * timeForceScale + minCharge);
      coinCharging = false;
      coinCharge = 0;
    }
  }
  void Toss(float power) {
    coin.transform.parent = null;
    coinRB.freezeRotation = false;
    coinRB.constraints = 0;
    Vector3 dir = coinTarget.transform.position - cameraTransform.position;
    coinRB.AddForce(dir.normalized * power * baseCoinForce);
    coin.gameObject.GetComponent<Collider>().enabled = true;
    coin.gameObject.GetComponent<CoinSpin>().enabled = true;
    coin = Instantiate(queue.NewCoin(), coinHolder.transform);
    coinRB = coin.transform.GetComponent<Rigidbody>();
  }
}
