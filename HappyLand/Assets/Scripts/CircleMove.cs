using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMove : MonoBehaviour {

	private float RotateSpeed = 3f;
	private float angle;
	public float direction;
	public GameObject circle;

	private void Start()
	{
	}

	private void Update()
	{

			angle += RotateSpeed * Time.deltaTime;
			transform.rotation = Quaternion.Euler(0,angle,0);
			circle.transform.rotation = Quaternion.Euler(0,0,-1* direction* angle);
	}
}
