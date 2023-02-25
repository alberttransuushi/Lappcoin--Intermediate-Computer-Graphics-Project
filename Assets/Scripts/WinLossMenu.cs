using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinLossMenu : MonoBehaviour
{
  public List<GameObject> items;
  public int killsToWin;
  public bool loss;
  bool endLocked = false;
  private void Update() {
    if (loss && !endLocked) {
      items[0].GetComponent<Text>().text = "YOU LOSS";
      endLocked = true;
    }
    if (EnemyUtility.GetKills() >= killsToWin && !endLocked) {
      items[0].GetComponent<Text>().text = "YOU WON";
      endLocked = true;
    }
    if (endLocked) {
      Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;
      Time.timeScale = 0;
      for (int i = 0; i < items.Count; i++) {
        items[i].SetActive(true);
      }
    }

  }
  public void LoadScene(string scene) {
    SceneManager.LoadScene(scene);
  }
  public void QuitGame() {
    Application.Quit();
  }
}
