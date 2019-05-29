using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleOffScreen : MonoBehaviour {

  void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == "Collector") {
			gameObject.SetActive(false);
      DestroyOnTouch.passTouchActivation = false;
		}
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
