using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
  public int highScore;
  public int level;
  public float[] position;

  public PlayerData(Player player)
  {
    level = player.level;
    // 4 is number of levels
    highScore = player.highScore;


    position = new float[3];
    position[0] = player.transform.position.x;
    position[1] = player.transform.position.y;
    position[2] = player.transform.position.z;
  }

}
