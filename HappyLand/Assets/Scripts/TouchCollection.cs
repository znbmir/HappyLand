using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCollection : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Select Stage
                if (hit.transform.name == "SquareL")
                {
                  Debug.Log("clickedL");
                }

                else if (hit.transform.name == "SquareR")
                {
                  Debug.Log("clickedR");
                }
            }
        }

    }
}
