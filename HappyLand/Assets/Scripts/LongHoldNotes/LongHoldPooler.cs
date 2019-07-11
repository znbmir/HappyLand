using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class LongHoldPooler : MonoBehaviour
{
  public static LongHoldPooler SharedInstance;
  void Awake(){
    SharedInstance = this;
  }

  public List<GameObject> LHPooledLeft;
	public List<GameObject> LHPooledRight;

	public GameObject LHToPoolLeft;
	public GameObject LHToPoolRight;

  public int amountToPool;

    // Start is called before the first frame update
    void Start()
    {
      LHPooledLeft = new List<GameObject>();
  		for (int i = 0; i < amountToPool; i++) {
  			GameObject obj = (GameObject)Instantiate(LHToPoolLeft);
  			obj.SetActive(false);
  			LHPooledLeft.Add(obj);
  		}

  		LHPooledRight = new List<GameObject>();
  		for (int i = 0; i < amountToPool; i++) {
  			GameObject obj = (GameObject)Instantiate(LHToPoolRight);
  			obj.SetActive(false);
  			LHPooledRight.Add(obj);
  		}
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject GetPooledLHNote(List<GameObject> LHPooled) {
  		//1
  		for (int i = 0; i < LHPooled.Count; i++) {
  			//2
  			if (!LHPooled[i].activeInHierarchy) {
  				return LHPooled[i];
  			}
  		}
  			//3
  			return null;
  	}


}
