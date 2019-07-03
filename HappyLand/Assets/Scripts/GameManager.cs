using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

  //GameOver
  public RectTransform panelGameOver;
  public Text TxtGameOver;
  private bool gameOver = false;

  public AudioSource theMusic;
  static public bool startPlaying;
  public SpawnNote theSpawnNote;

  public int currentScore;
  public int scorePerNote = 100;

  public int currentMultiplier;
  public int multiplierTracker;
  public int[] multiplierThresholds;

  public Text scoreText;
  public Text multiText;
  static public int score = 0;


  private float RotateSpeed = 10f;
  private float angle;
  public GameObject circleInside;
  public GameObject circleOutside;

  static public float _healthValue = 100f;
  public Image _bar;

  private static GameManager _instance = null;
  public static GameManager Instance{
    get{if(_instance == null){
      _instance = new GameManager();
      }
      return _instance;
    }
  }

  private GameManager(){
    _instance = this;
  }

private void OnGameOver()
{
  panelGameOver.gameObject.SetActive(true);
  TxtGameOver.text = GameManager.Instance.gameOver ? "You Loose" : "You Won";
}
    // Start is called before the first frame update
    void Start()
    {
      scoreText.text = "Score: 0";
      currentMultiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {

      scoreText.text = "" + currentScore;
      multiText.text = "" + currentMultiplier;
      if( _healthValue == 0)
      {
        gameOver = true;
        OnGameOver();
      }

      if(!startPlaying)
      {
        if(Input.anyKeyDown)
        {
          startPlaying = true;
          theSpawnNote.hasStarted = true;

          theMusic.Play();
        }
      }

      MoveCircle(circleInside, -1);
      MoveCircle(circleOutside, 1);
    }

    void MoveCircle(GameObject _circle, int _direction)
    {
      //Move circle around
      angle += RotateSpeed * Time.deltaTime;
      transform.rotation = Quaternion.Euler(0,angle,0);
      _circle.transform.rotation = Quaternion.Euler(0,0,-1* _direction* angle);
    }

    public void HealthChange(float healthValue){
      float amount = (healthValue/100.0f);
      _bar.fillAmount = amount;
    }

    public void NoteHit()
    {
      Debug.Log("Hit On Time");

      if(currentMultiplier - 1 < multiplierThresholds.Length)
      {
        multiplierTracker++;
        if(multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
        {
          multiplierTracker = 0;
          currentMultiplier++;
        }
      }

      multiText.text = "Multiplier: x" + currentMultiplier;

      currentScore += scorePerNote * currentMultiplier;
      scoreText.text = "" + currentScore;
    }

    public void NoteMissed()
    {

      if(currentMultiplier > 1)
      currentMultiplier--;
    }

}
