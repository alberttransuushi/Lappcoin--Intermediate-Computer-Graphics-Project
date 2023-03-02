using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameUtility
{
  static int seed;
  public static void SetSeed(int s) {
    seed = s;
  }
  public static int GetSeed() {
    return seed;
  }
}
