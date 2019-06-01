using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{
  public static ObjectPooler SharedInstance;
  void Awake(){
    SharedInstance = this;
  }

  public List<GameObject> notesPooledLeft;
	public List<GameObject> notesPooledRight;

	public GameObject noteToPoolLeft;
	public GameObject noteToPoolRight;

  public int amountToPool;

    // Start is called before the first frame update
    void Start()
    {
      notesPooledLeft = new List<GameObject>();
  		for (int i = 0; i < amountToPool; i++) {
  			GameObject obj = (GameObject)Instantiate(noteToPoolLeft);
  			obj.SetActive(false);
  			notesPooledLeft.Add(obj);
  		}

  		notesPooledRight = new List<GameObject>();
  		for (int i = 0; i < amountToPool; i++) {
  			GameObject obj = (GameObject)Instantiate(noteToPoolRight);
  			obj.SetActive(false);
  			notesPooledRight.Add(obj);
  		}
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject GetPooledNote(List<GameObject> notesPooled) {
  		//1
  		for (int i = 0; i < notesPooled.Count; i++) {
  			//2
  			if (!notesPooled[i].activeInHierarchy) {
  				return notesPooled[i];
  			}
  		}
  			//3
  			return null;
  	}


}
