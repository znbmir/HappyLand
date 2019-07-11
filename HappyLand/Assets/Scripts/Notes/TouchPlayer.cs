using System.Runtime.InteropServices.ComTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TouchPlayer : MonoBehaviour
{

  public static bool isTouchPlayer = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isTouchPlayer)
        {
          if(gameObject.GetComponent< TrigerTouchActivation >().passTouchActivation)
            {
              Debug.Log("Player Detected");
              gameObject.SetActive(false);
              gameObject.GetComponent< TrigerTouchActivation >().passTouchActivation =false;
              //GameManager.score++;
              GameManager.Instance.NoteHit();
            }
        }
    }
}
