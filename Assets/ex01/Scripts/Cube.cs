using UnityEngine;

public class Cube : MonoBehaviour
{

	public KeyCode key;
	public float speed;

	private Vector3 cacheVec;

	private float targetPosY;
	
	// Use this for initialization
	void Start ()
	{
		targetPosY = -transform.position.y;
		speed = Random.Range(8f, 15f);
		Debug.Log(Camera.main.rect.yMax);
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate(0,-speed * Time.deltaTime, 0);

		if (Input.GetKeyDown(key))
		{
			float precision = transform.position.y - targetPosY;
			precision = precision > 0 ? precision : precision * -1;
			Debug.Log("Precision: " + precision);
			Destroy(gameObject);
		}		
		if (transform.localPosition.y < Camera.main.transform.localPosition.y - Camera.main.orthographicSize * 1.2)
			Destroy(gameObject);
	}
}
