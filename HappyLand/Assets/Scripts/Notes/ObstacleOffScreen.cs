using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleOffScreen : MonoBehaviour {

  void OnTriggerEnter(Collider target) {
		if (target.tag == "Collector") {
      gameObject.GetComponent<Collider>().gameObject.GetComponent< TrigerTouchActivation >().passTouchActivation =false;
			gameObject.SetActive(false);
		}
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
