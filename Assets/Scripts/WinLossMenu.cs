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
  bool triggered;
    private void Update()
    {
        if (loss && !endLocked && !triggered)
        {
            items[0].GetComponent<Text>().text = "YOU LOSS";
            endLocked = true;
        }
        if (EnemyUtility.GetKills() >= killsToWin && !endLocked && !triggered)
        {
            items[0].GetComponent<Text>().text = "YOU WON";
            endLocked = true;
        }
        if (endLocked && !triggered)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            for (int i = 0; i < items.Count; i++)
            {
                items[i].SetActive(true);
            }
            triggered = true;
        }

    }
    public void LoadScene(string scene)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        for (int i = 0; i < items.Count; i++)
        {
            items[i].SetActive(false);
        }

        EnemyUtility.AddKills(-EnemyUtility.GetKills());

        SceneManager.LoadScene(scene);

    }
    public void QuitGame() {

        Application.Quit();
    }
}
