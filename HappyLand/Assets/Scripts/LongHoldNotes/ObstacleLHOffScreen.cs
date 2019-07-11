using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObstacleLHOffScreen : MonoBehaviour {

  public float waitTime;
  float waitTimeBegin=0;

  void OnTriggerEnter(Collider target) {
		if (target.tag == "Collector") {
      gameObject.GetComponent<Collider>().gameObject.GetComponent< TrigerTouchActivation >().passTouchActivation =false;
      gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
      StartCoroutine(UpdateCoroutine(waitTime, waitTimeBegin));
			//gameObject.SetActive(false);

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
//waitTime, waitTimeBegin
  IEnumerator UpdateCoroutine(float wT, float wTB)
  {
    yield return new WaitForSeconds(wT);
    gameObject.SetActive(false);
  }

}
