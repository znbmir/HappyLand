using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObstacleOffScreen : MonoBehaviour {

  void OnTriggerEnter(Collider target) {
		if (target.tag == "Collector") {
      gameObject.GetComponent<Collider>().gameObject.GetComponent< TrigerTouchActivation >().passTouchActivation =false;
			gameObject.SetActive(false);

      GameManager._healthValue = GameManager._healthValue - 2f;
      GameManager.Instance.HealthChange(GameManager._healthValue);
      GameManager.Instance.NoteMissed();
		}
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

}
