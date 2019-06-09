using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BreathBarScript : MonoBehaviour {

public Image _bar;
public float _breathValue = 0;
//public GameObject micVolume;
public GameObject BreathBarObj;
//public ParticleSystem musicParticle;
//public AudioSource musicParticleSound;





// Use this for initialization
  void Start () {
    //musicParticleSound = GetComponent<AudioSource> ();
    BreathBarObj = GameObject.Find ("BreathBar");
		BreathChange(_breathValue);

	}
	// Update is called once per frame
  void FixedUpdate() {
  //  if (Boat.playFinished)
    //{
    //  BreathBarObj.SetActive (false);
  //  }

  //  else if (BreathRecord.PracticeFinish)
//    {
//      BreathBarObj.SetActive (false);
//      SceneManager.LoadScene("_watering");

//    }
  }






//	else if (Boat.BlowingStop && !CloudBreathing.BreathOutStart && !BreathRecord.PracticeFinish)
  //  gameObject.SetActive (false);


	void BreathChange(float breathValue){
		float amount = (breathValue/100.0f);
		_bar.fillAmount = amount;
	}
}
