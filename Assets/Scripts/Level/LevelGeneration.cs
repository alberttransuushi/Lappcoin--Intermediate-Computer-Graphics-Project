using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
  [SerializeField] List<GameObject> levelSquares;
  [SerializeField] int seed;
  [SerializeField] int levelSize;
  Transform playerTrans;
  Vector2 playerLocationGrid;
  private void Start() {
    SetSeed();
    if (seed != 0) {
      Random.InitState(seed);
    } else {
      Random.InitState(1);
    }
  }
  private void Update() {
    if (playerTrans.position.x % levelSize != playerLocationGrid.x) {
      //DELOAD

      playerLocationGrid.x = playerTrans.position.x % levelSize;
      
    }
    if (playerTrans.position.y % levelSize != playerLocationGrid.y) {


      playerLocationGrid.y = playerTrans.position.y % levelSize;
      
    }

  }
  public void SetSeed() {
    seed = GameUtility.GetSeed();
  }
}
