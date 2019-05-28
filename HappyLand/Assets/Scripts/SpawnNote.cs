using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNote : MonoBehaviour {

	[SerializeField]
	GameObject noteTouchLeft;
  [SerializeField]
  GameObject noteTouchRight;

  [SerializeField]
  GameObject spawnPoint;

  [SerializeField]
  GameObject yourCanvasVariable;

	Vector2 startPoint;

	float radius;
	public float beatTempo;
  private float moveSpeed;

	public bool hasStarted;

  float angleLeft = 210f;
  float angleRight = 150f;

	public NoteType[] noteTypeLeft;
	public NoteType[] noteTypeRight;

	public int currentNoteIndex = 0;
	public NoteType currentNoteLeft;
	public NoteType currentNoteRight;


	public enum NoteType
	{
		None,
		Touch,
		DropDown,
		DropUp,
		TouchHold
	};

	// Use this for initialization
	void Start () {
		radius = 5f;
		//moveSpeed = 200f;
    startPoint = new Vector2(0, 2);
    InvokeRepeating("SpawnNoteLeft", 0, 2);
    InvokeRepeating("SpawnNoteRight", 0, 2);

		moveSpeed = beatTempo / 60f;

	}


	// Update is called once per frame
	void Update () {
  //  Random.Range ((int)(0.1 * seconds), (int)(0.2 * seconds));
		//if (Input.GetButtonDown ("Fire1")) {
			//startPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);

			//SpawnProjectiles ();
		//}
	}

	void SpawnNoteLeft()
	{
		if(hasStarted){

    currentNoteLeft = noteTypeLeft[currentNoteIndex];
    currentNoteIndex++;

		switch (currentNoteLeft)
		{
			case NoteType.None:
		  print ("None NoteType^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
			break;
			case NoteType.Touch:
			{
				float myButtonXPosition = spawnPoint.transform.position.x + Mathf.Sin ((angleLeft * Mathf.PI) / 180) * radius;
				float myButtonYPosition = spawnPoint.transform.position.y + Mathf.Cos ((angleLeft * Mathf.PI) / 180) * radius;
				Vector3 myButtonVector = new Vector3 (myButtonXPosition, myButtonYPosition, 0);
				Vector3 myButtonMoveDirection = (myButtonVector - spawnPoint.transform.position).normalized * moveSpeed;


				GameObject myButton = ObjectPooler.SharedInstance.GetPooledNote(ObjectPooler.SharedInstance.notesPooledLeft);
				if (myButton != null) {
					myButton.transform.position = spawnPoint.transform.position;
					myButton.transform.rotation = spawnPoint.transform.rotation;
					myButton.SetActive(true);
				}

				//GameObject myButton = Instantiate (noteTouchLeft, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
				myButton.transform.SetParent(yourCanvasVariable.transform);
				myButton.GetComponent<Rigidbody2D> ().velocity = new Vector2 (myButtonMoveDirection.x, myButtonMoveDirection.y);
				myButton.transform.rotation = Quaternion.Euler(0,0,-1*angleLeft);
			}
			break;
			default:
			print ("Incorrect NoteType^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
			break;
		}
	}


	}




  void SpawnNoteRight()
  {
		if(hasStarted){

    currentNoteRight = noteTypeRight[currentNoteIndex];

		switch (currentNoteRight)
		{
			case NoteType.None:
			print ("None NoteType^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
			break;
			case NoteType.Touch:
			{
				float myButtonXPosition = spawnPoint.transform.position.x + Mathf.Sin ((angleRight * Mathf.PI) / 180) * radius;
				float myButtonYPosition = spawnPoint.transform.position.y + Mathf.Cos ((angleRight * Mathf.PI) / 180) * radius;
				Vector3 myButtonVector = new Vector3 (myButtonXPosition, myButtonYPosition, 0);
				Vector3 myButtonMoveDirection = (myButtonVector - spawnPoint.transform.position).normalized * moveSpeed;

				GameObject myButton = ObjectPooler.SharedInstance.GetPooledNote(ObjectPooler.SharedInstance.notesPooledRight);
				if (myButton != null) {
					myButton.transform.position = spawnPoint.transform.position;
					myButton.transform.rotation = spawnPoint.transform.rotation;
					myButton.SetActive(true);
				}

				//GameObject myButton = Instantiate (noteTouchRight, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
				myButton.transform.SetParent(yourCanvasVariable.transform);
				myButton.GetComponent<Rigidbody2D> ().velocity = new Vector2 (myButtonMoveDirection.x, myButtonMoveDirection.y);
				myButton.transform.rotation = Quaternion.Euler(0,0,-1*angleRight);
			}
			break;
			default:
			print ("Incorrect NoteType^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
			break;
		}
	}
}

}
