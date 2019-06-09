using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerTouchActivation : MonoBehaviour
{
  public bool passTouchActivation = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider target) {
      if (target.tag == "TouchActivation") {
        //Debug.Log("touch activated");
        passTouchActivation = true;
      }
    }
}
