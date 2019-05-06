
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour {

	[SerializeField]
	GameObject cubeLeft;
  [SerializeField]
  GameObject cubeRight;


	Vector2 startPoint;

	float radius, moveSpeed;
  float angleLeft = 210f;
  float angleRight = 150f;




	// Use this for initialization
	void Start () {
		radius = 5f;
		moveSpeed = 1f;
    startPoint = new Vector2(0, 0);
    InvokeRepeating("SpawnCubeLeft", 0, 2);
    InvokeRepeating("SpawnCubeRight", 0, 3);

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

			float projectileDirXposition = startPoint.x + Mathf.Sin ((angleLeft * Mathf.PI) / 180) * radius;
			float projectileDirYposition = startPoint.y + Mathf.Cos ((angleLeft * Mathf.PI) / 180) * radius;

			Vector2 projectileVector = new Vector2 (projectileDirXposition, projectileDirYposition);
			Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * moveSpeed;

			var proj = Instantiate (cubeLeft, startPoint, Quaternion.identity);
			proj.GetComponent<Rigidbody2D> ().velocity =
				new Vector2 (projectileMoveDirection.x, projectileMoveDirection.y);
			proj.transform.rotation = Quaternion.Euler(0,0,-1*angleLeft);
	}

  void SpawnCubeRight()
  {

      float projectileDirXposition = startPoint.x + Mathf.Sin ((angleRight * Mathf.PI) / 180) * radius;
      float projectileDirYposition = startPoint.y + Mathf.Cos ((angleRight * Mathf.PI) / 180) * radius;

      Vector2 projectileVector = new Vector2 (projectileDirXposition, projectileDirYposition);
      Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * moveSpeed;

      var proj = Instantiate (cubeRight, startPoint, Quaternion.identity);
      proj.GetComponent<Rigidbody2D> ().velocity =
        new Vector2 (projectileMoveDirection.x, projectileMoveDirection.y);
			proj.transform.rotation = Quaternion.Euler(0,0,-1*angleRight);

			}

}
