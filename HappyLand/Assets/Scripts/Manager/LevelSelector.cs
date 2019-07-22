using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
  int highScore;

  public void Select (int level)
  {
    GameManager.level = level;
    Debug.Log(level);
    //int highScore = LoadPlayer(level.ToString());
  //  GameManager.highScore = highScore;
    SceneManager.LoadScene("PlayScene");
  }

  public void Levels ()
  {
    //int level = GameManager.level;
    //int highScore = LoadPlayer(level.ToString());
    //if (GameManager.highScore > highScore) highScore = GameManager.highScore;
    SceneManager.LoadScene("LevelSelect");
  }

/*  public int LoadPlayer (string levelPath)
  {
    PlayerData data = SaveSystem.LoadPlayer(levelPath);

    int highScore = data.highScore;
    return highScore;
  }*/


}
