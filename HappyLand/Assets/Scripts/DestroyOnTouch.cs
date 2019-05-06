using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTouch : MonoBehaviour
{

  public bool passTochActivation = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D target) {
      if (target.tag == "TouchActivation") {
        Debug.Log("touch activated");
        passTochActivation = true;
      }
    }

    void OnMouseDown()
    {
      Debug.Log("Something touched");
      if(passTochActivation)
      {
        Destroy(gameObject);
        ScoreCounter.score++;
      }

    }
}
