using UnityEngine;

public class ScaleAccrDistance : MonoBehaviour {

	public float maxdistance = 10;
  public GameObject originPoint;
	float tempX, tempY;
  public string direction;

	void Start ()
	{
		tempY = transform.localScale.y;
    tempX = transform.localScale.x;
	}

	void Update ()
    {

      //Appear Color for Left and Right Notes
      if(direction == "Left")
      GetComponent<SpriteRenderer>().color = SpawnNote.realcolorLeft;
      else
      GetComponent<SpriteRenderer>().color = SpawnNote.realcolorRight;

      //Scale Note according to distance from SpawnPoint
      Vector3 pp = originPoint.transform.position;

      float distance = Vector2.Distance(transform.position, pp);

      if (distance < maxdistance)
      {
        float s = maxdistance - distance;
        transform.localScale = new Vector3(tempX-(s * tempX/maxdistance), tempY-(s * tempY/maxdistance), transform.localScale.z);
      }
    }

}
