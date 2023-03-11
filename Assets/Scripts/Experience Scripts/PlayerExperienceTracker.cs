using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExperienceTracker : MonoBehaviour
{
  float playerExp;
  int playerLevel;
  float neededExpForLevelUp;
  float levelScaling;
  private void Start() {
    CalculateLevelExperienceNeeded();
  }
  private void Update() {
    if (playerExp >= neededExpForLevelUp) {
      LevelUp();
    }
  }
  void CalculateLevelExperienceNeeded() {
    //(4(x+1))^{s}-4x^{s}
    neededExpForLevelUp = 4 * Mathf.Pow(playerLevel + 1, levelScaling) - 4 * Mathf.Pow(playerLevel, levelScaling);
    
  }

  public void AddExp(float exp) {
    playerExp += exp;
  }
  private void LevelUp() {
    playerExp -= neededExpForLevelUp;
    playerLevel += 1;
    //INSERT UI CODE HERE

    CalculateLevelExperienceNeeded();
  }
}
