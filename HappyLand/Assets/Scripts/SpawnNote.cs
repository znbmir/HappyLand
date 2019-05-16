
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNote : MonoBehaviour {

	[SerializeField]
	GameObject cubeLeft;
  [SerializeField]
  GameObject cubeRight;

  [SerializeField]
  GameObject spawnPoint;

  [SerializeField]
  GameObject yourCanvasVariable;

	Vector2 startPoint;

	float radius;

  public float moveSpeed;
  float angleLeft = 210f;
  float angleRight = 150f;

	public enum NoteType
	{
		None,
		Touch,
		DropDown,
		DropUp,
		TouchHold
	};


	public NoteType[] noteTypeLeft;
	public NoteType[] noteTypeRight;

	public int currentNoteIndex = 0;
	public NoteType currentNote;


	// Use this for initialization
	void Start () {
		radius = 5f;
		moveSpeed = 70f;
    startPoint = new Vector2(0, 2);
    InvokeRepeating("SpawnCubeLeft", 0, 2);
    InvokeRepeating("SpawnCubeRight", 0, 2);

		currentNote = noteTypeLeft[currentNoteIndex];

	}

	// Update is called once per frame
	void Update () {
  //  Random.Range ((int)(0.1 * seconds), (int)(0.2 * seconds));
		//if (Input.GetButtonDown ("Fire1")) {
			//startPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);

			//SpawnProjectiles ();
		//}
	}

	void SpawnCubeLeft()
	{
    currentNote = noteTypeLeft[currentNoteIndex];
    //qSwitchStatement(currentNote);
    currentNoteIndex++;

    float myButtonXPosition = spawnPoint.transform.position.x + Mathf.Sin ((angleLeft * Mathf.PI) / 180) * radius;
    float myButtonYPosition = spawnPoint.transform.position.y + Mathf.Cos ((angleLeft * Mathf.PI) / 180) * radius;
    Vector3 myButtonVector = new Vector3 (myButtonXPosition, myButtonYPosition, 0);
    Vector3 myButtonMoveDirection = (myButtonVector - spawnPoint.transform.position).normalized * moveSpeed;

    GameObject myButton = Instantiate (cubeLeft, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
    myButton.transform.SetParent(yourCanvasVariable.transform);
    myButton.GetComponent<Rigidbody2D> ().velocity = new Vector2 (myButtonMoveDirection.x, myButtonMoveDirection.y);
    myButton.transform.rotation = Quaternion.Euler(0,0,-1*angleLeft);
	}

  void SpawnCubeRight()
  {
    currentNote = noteTypeRight[currentNoteIndex];
    //qSwitchStatement(currentNote);

    float myButtonXPosition = spawnPoint.transform.position.x + Mathf.Sin ((angleRight * Mathf.PI) / 180) * radius;
    float myButtonYPosition = spawnPoint.transform.position.y + Mathf.Cos ((angleRight * Mathf.PI) / 180) * radius;
    Vector3 myButtonVector = new Vector3 (myButtonXPosition, myButtonYPosition, 0);
    Vector3 myButtonMoveDirection = (myButtonVector - spawnPoint.transform.position).normalized * moveSpeed;

    GameObject myButton = Instantiate (cubeRight, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
    myButton.transform.SetParent(yourCanvasVariable.transform);
    myButton.GetComponent<Rigidbody2D> ().velocity = new Vector2 (myButtonMoveDirection.x, myButtonMoveDirection.y);
    myButton.transform.rotation = Quaternion.Euler(0,0,-1*angleRight);
}

			void SwitchStatement(){}
		}
