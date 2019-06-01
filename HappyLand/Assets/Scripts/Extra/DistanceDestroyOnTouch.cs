using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceDestroyOnTouch : MonoBehaviour {

  [SerializeField]
  GameObject spawnPoint;

  [SerializeField]
  float radius;

  [SerializeField]
  float distance;
	// Use this for initialization
	void Start () {
    distance = 0;
	}

	// Update is called once per frame
	void Update () {
    distance = Vector3.Distance(gameObject.transform.position, spawnPoint.transform.position);
    Debug.Log(distance);

    if (distance > radius) {
      gameObject.SetActive(false);
    }
	}

}
