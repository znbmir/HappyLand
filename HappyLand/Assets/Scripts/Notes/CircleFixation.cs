using UnityEngine;

public class CircleFixation : MonoBehaviour {

	public bool IsInEditor;
	private Ray _tileDetectRay;
	private RaycastHit _tileHit;
	bool isTouched = false;

	public float maxScale = 1.2f;
	public float scale = 0.001f;
	public Color circleColor;

  public GameObject originPoint;

	void Start ()
	{
		this.transform.position = originPoint.transform.position;
		GetComponent<SpriteRenderer>().color = circleColor;

	}

	void Update ()
    {
			if(transform.localScale.y < maxScale && GameManager.startPlaying)
			{
				transform.localScale = new Vector3(transform.localScale.x + scale, transform.localScale.y + scale, transform.localScale.z);
			}

			//For PC Mouse Click
			if (IsInEditor)
			{
					if (Input.GetMouseButtonDown(0))
					{
						_tileDetectRay = Camera.main.ScreenPointToRay(Input.mousePosition);
						Debug.DrawRay(_tileDetectRay.origin , _tileDetectRay.direction * 1000 , Color.green);
					}
				}

				//For Mobile Screen Touch
				if (Input.touchCount > 0)
				{
					for (int i = 0; i < Input.touchCount ; i++)
					{
						var touch = Input.GetTouch(i);
						if (Input.GetTouch(i).phase == TouchPhase.Began)
						{
							_tileDetectRay = Camera.main.ScreenPointToRay(Input.mousePosition);
							Debug.DrawRay(_tileDetectRay.origin , _tileDetectRay.direction * 1000 , Color.green);
							if (Physics.Raycast(_tileDetectRay, out _tileHit, 1000))
							{
								if (_tileHit.collider.tag == "Circle")
								{
									isTouched = true;
								}
							}
						}
					}
				}



			}
		}
