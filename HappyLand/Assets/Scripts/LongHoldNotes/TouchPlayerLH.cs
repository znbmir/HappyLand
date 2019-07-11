using System.Runtime.InteropServices.ComTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TouchPlayerLH : MonoBehaviour
{

  public static bool isTouchPlayerLH = false;
  public bool holdBegan = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isTouchPlayerLH)
        {
          if(gameObject.GetComponent< TrigerTouchActivation >().passTouchActivation)
            {
              Debug.Log("PlayerLH Detected");
              gameObject.SetActive(false);
              //gameObject.GetComponent< TrigerTouchActivation >().passTouchActivation = false;
              float lastTime = 0;
              if(Time.time - lastTime > 0.2)
              {
                GameManager.Instance.NoteHit();
                lastTime = Time.time;
              }
            }
        }
    }

    public void LongHoldPressed()
    {
      holdBegan = true;
    }

    public void LongHoldReleased()
    {
      holdBegan = false;
    }

}
