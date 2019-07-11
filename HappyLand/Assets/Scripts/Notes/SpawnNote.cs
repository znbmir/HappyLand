using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNote : MonoBehaviour {



  [SerializeField]
  GameObject spawnPoint;

  [SerializeField]
  GameObject yourCanvasVariable;

	Vector2 startPoint;

	float radius;
	public float beatTempo;
  private float moveSpeed;

	public bool hasStarted;

  //float angleLeft = 210f;
  //float angleRight = 150f;

	public NoteType[] noteTypeLeft;
	public NoteType[] noteTypeRight;

	public NoteColor[] noteColorLeft;
	public NoteColor[] noteColorRight;

	public int currentNoteIndex = 0;
	public NoteType currentNoteLeft;
	public NoteType currentNoteRight;
	static public Color realcolorLeft;
	static public Color realcolorRight;
	static public NoteColor currentNoteColorLeft;
	static public NoteColor currentNoteColorRight;

	public float[] angleLeft;
	public float[] angleRight;

	public enum NoteType
	{
		None,
		Touch,
		DropDown,
		DropUp,
		LongHold
	};

	public enum NoteColor
	{
		Red,
		Green,
		Blue
	};

	// Use this for initialization
	void Start () {

		radius = 5f;
		//moveSpeed = 200f;
    startPoint = new Vector2(0, 2);
    InvokeRepeating("SpawnNoteLeft", 0, 1f);
    InvokeRepeating("SpawnNoteRight", 0, 1f);

		moveSpeed = beatTempo / 60f;


	}


	// Update is called once per frame
	void FixedUpdate () {

	}

	void SpawnNoteLeft()
	{
		if(hasStarted){

    currentNoteLeft = noteTypeLeft[currentNoteIndex];
		currentNoteRight = noteTypeRight[currentNoteIndex];
		currentNoteColorLeft = noteColorLeft[currentNoteIndex];
    currentNoteColorRight = noteColorRight[currentNoteIndex];

    currentNoteIndex++;

		switch (currentNoteLeft)
		{
			case NoteType.None:
		  //print ("None NoteType^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
			break;
			case NoteType.Touch:
			{
				float myButtonXPosition = spawnPoint.transform.position.x + Mathf.Sin ((angleLeft[currentNoteIndex] * Mathf.PI) / 180) * radius;
				float myButtonYPosition = spawnPoint.transform.position.y + Mathf.Cos ((angleLeft[currentNoteIndex] * Mathf.PI) / 180) * radius;
				Vector3 myButtonVector = new Vector3 (myButtonXPosition, myButtonYPosition, 0);
				Vector3 myButtonMoveDirection = (myButtonVector - spawnPoint.transform.position).normalized * moveSpeed;


				GameObject myButton = ObjectPooler.SharedInstance.GetPooledNote(ObjectPooler.SharedInstance.notesPooledLeft);
				if (myButton != null) {
					myButton.transform.position = spawnPoint.transform.position;
					myButton.transform.rotation = spawnPoint.transform.rotation;
					//keep color to use in ScaleAcrDistance
					realcolorLeft = myButton.GetComponent<SpriteRenderer> ().color;
					//fade color for first frame
					myButton.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .01f);
					myButton.SetActive(true);
				}

				//GameObject myButton = Instantiate (noteTouchLeft, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
				myButton.transform.SetParent(yourCanvasVariable.transform);
				myButton.GetComponent<Rigidbody> ().velocity = new Vector2 (myButtonMoveDirection.x, myButtonMoveDirection.y);
				myButton.transform.rotation = Quaternion.Euler(0,0,-1*angleLeft[currentNoteIndex]);
			}
			break;


			//LongHold Not Spawning
			case NoteType.LongHold:
			{
				float myButtonXPosition = spawnPoint.transform.position.x + Mathf.Sin ((angleLeft[currentNoteIndex] * Mathf.PI) / 180) * radius;
				float myButtonYPosition = spawnPoint.transform.position.y + Mathf.Cos ((angleLeft[currentNoteIndex] * Mathf.PI) / 180) * radius;
				Vector3 myButtonVector = new Vector3 (myButtonXPosition, myButtonYPosition, 0);
				Vector3 myButtonMoveDirection = (myButtonVector - spawnPoint.transform.position).normalized * moveSpeed;


				GameObject myButton = LongHoldPooler.SharedInstance.GetPooledLHNote(LongHoldPooler.SharedInstance.LHPooledLeft);
				if (myButton != null) {
					myButton.transform.position = spawnPoint.transform.position;
					myButton.transform.rotation = spawnPoint.transform.rotation;
					//keep color to use in ScaleAcrDistance
					realcolorLeft = myButton.GetComponent<SpriteRenderer> ().color;
					//fade color for first frame
					myButton.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .01f);
					myButton.SetActive(true);
				}

				//GameObject myButton = Instantiate (noteTouchLeft, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
				myButton.transform.SetParent(yourCanvasVariable.transform);
				myButton.GetComponent<Rigidbody> ().velocity = new Vector2 (myButtonMoveDirection.x, myButtonMoveDirection.y);
				myButton.transform.rotation = Quaternion.Euler(0,0,-1*angleLeft[currentNoteIndex]);
			}
			break;
			default:
			//print ("Incorrect NoteType^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
			break;
		}
	}


	}




  void SpawnNoteRight()
  {
		if(hasStarted){

		switch (currentNoteRight)
		{
			case NoteType.None:
			//print ("None NoteType^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
			break;
			case NoteType.Touch:
			{
				float myButtonXPosition = spawnPoint.transform.position.x + Mathf.Sin ((angleRight[currentNoteIndex] * Mathf.PI) / 180) * radius;
				float myButtonYPosition = spawnPoint.transform.position.y + Mathf.Cos ((angleRight[currentNoteIndex] * Mathf.PI) / 180) * radius;
				Vector3 myButtonVector = new Vector3 (myButtonXPosition, myButtonYPosition, 0);
				Vector3 myButtonMoveDirection = (myButtonVector - spawnPoint.transform.position).normalized * moveSpeed;

				GameObject myButton = ObjectPooler.SharedInstance.GetPooledNote(ObjectPooler.SharedInstance.notesPooledRight);
				if (myButton != null) {
					myButton.transform.position = spawnPoint.transform.position;
					myButton.transform.rotation = spawnPoint.transform.rotation;

					//keep color to use in ScaleAcrDistance
					realcolorRight = myButton.GetComponent<SpriteRenderer> ().color;
					//fade color for first frame
					myButton.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .01f);
					myButton.SetActive(true);
				}

				//GameObject myButton = Instantiate (noteTouchRight, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
				myButton.transform.SetParent(yourCanvasVariable.transform);
				myButton.GetComponent<Rigidbody> ().velocity = new Vector2 (myButtonMoveDirection.x, myButtonMoveDirection.y);
				myButton.transform.rotation = Quaternion.Euler(0,0,-1*angleRight[currentNoteIndex]);

			}
			break;

			//LongHold Not Spawning
			case NoteType.LongHold:
			{
				float myButtonXPosition = spawnPoint.transform.position.x + Mathf.Sin ((angleRight[currentNoteIndex] * Mathf.PI) / 180) * radius;
				float myButtonYPosition = spawnPoint.transform.position.y + Mathf.Cos ((angleRight[currentNoteIndex] * Mathf.PI) / 180) * radius;
				Vector3 myButtonVector = new Vector3 (myButtonXPosition, myButtonYPosition, 0);
				Vector3 myButtonMoveDirection = (myButtonVector - spawnPoint.transform.position).normalized * moveSpeed;

				GameObject myButton = LongHoldPooler.SharedInstance.GetPooledLHNote(LongHoldPooler.SharedInstance.LHPooledRight);
				if (myButton != null) {
					myButton.transform.position = spawnPoint.transform.position;
					myButton.transform.rotation = spawnPoint.transform.rotation;

					//keep color to use in ScaleAcrDistance
					realcolorRight = myButton.GetComponent<SpriteRenderer> ().color;
					//fade color for first frame
					myButton.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .01f);
					myButton.SetActive(true);
				}

				//GameObject myButton = Instantiate (noteTouchRight, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
				myButton.transform.SetParent(yourCanvasVariable.transform);
				myButton.GetComponent<Rigidbody> ().velocity = new Vector2 (myButtonMoveDirection.x, myButtonMoveDirection.y);
				myButton.transform.rotation = Quaternion.Euler(0,0,-1*angleRight[currentNoteIndex]);
			}
			break;

			default:
			//print ("Incorrect NoteType^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
			break;
		}
	}
}

//Color SetColor()

}
