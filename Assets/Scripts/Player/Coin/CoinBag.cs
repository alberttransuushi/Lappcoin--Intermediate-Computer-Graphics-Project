using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBag : MonoBehaviour
{
  [SerializeField] List<GameObject> coinBag;
  [SerializeField] List<GameObject> coinQueue;
  [SerializeField] Transform coinTrans;
  private void Start() {
    RerollQueue();
  }
  public GameObject NewCoin() {
    GameObject temp = coinQueue[0];
    coinQueue.RemoveAt(0);
    if (coinQueue.Count == 0) {
      RerollQueue();
    }
    return temp;
  }
  public void RerollQueue() {
    coinQueue.Clear();
    List<GameObject> tempCoinList = new List<GameObject>(coinBag);
    while (tempCoinList.Count > 0) {
      int randNum = Random.Range(0,tempCoinList.Count - 1);
      coinQueue.Add(tempCoinList[randNum]);
      tempCoinList.RemoveAt(randNum);
    }
  }
}
