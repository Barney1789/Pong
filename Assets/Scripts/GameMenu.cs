using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
  public void ShowStartGame()
    {
        SceneManager.LoadScene("Pong");
    }

    public void ShowLeaderBoard()
    {
        SceneManager.LoadScene("Scores");
    }
}
