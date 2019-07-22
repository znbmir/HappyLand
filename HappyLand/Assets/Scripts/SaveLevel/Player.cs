using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
  public int level;
  public int highScore;
  public  void SavePlayer (string levelPath)
  {
    SaveSystem.SavePlayer(this, levelPath);
  }

  public void LoadPlayer (string levelPath)
  {
    PlayerData data = SaveSystem.LoadPlayer(levelPath);

    level = data.level;

    highScore = data.highScore;


    Vector3 position;
    position.x = data.position[0];
    position.y = data.position[1];
    position.z = data.position[2];
    transform.position = position;
  }

  #region UI Methods

/*
  public void ChangeHighScore (int amount)
  {
    highScore += amount;
  }*/

  #endregion
}
