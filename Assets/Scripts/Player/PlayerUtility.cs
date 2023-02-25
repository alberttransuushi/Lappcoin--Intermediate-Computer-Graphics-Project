using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUtility : MonoBehaviour
{
  static GameObject player;
  public static void SetPlayer(GameObject p) {
    player = p;
  }
  public static GameObject GetPlayer() {
    if (player == null) {
      player = GameObject.Find("Player");
    }
    return player;
  }
}
