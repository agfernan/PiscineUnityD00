using UnityEditorInternal.VR;
using UnityEngine;

public class Ball : MonoBehaviour
{

	
	public bool moving;

	private float speed;
	private float direction;

	private int score = -15;
	
	private const float MAX_SPEED = 100;

	private Vector3 cacheVec;


	private float camTop;
	private float camBottom;

	public Club club;
	public Transform hole;
	
	// Use this for initialization
	void Start ()
	{
		moving = false;
		camTop = Camera.main.transform.position.y + Camera.main.orthographicSize;
		camBottom = Camera.main.transform.position.y - Camera.main.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
		if (moving)
		{
			float distToHole = hole.transform.position.y - transform.position.y;
			distToHole = distToHole < 0 ? -distToHole : distToHole;
			if (speed <= 3f && distToHole < .3f)
			{
				score -= 5;
				Debug.Log("Score: " + score);
				Destroy(gameObject);
				Destroy(club.gameObject);
			}

			transform.Translate(Vector3.up * direction * speed * Time.deltaTime);
						
			if (transform.position.y > camTop)
				direction = -1;
			else if (transform.position.y < camBottom)
				direction = 1;
			cacheVec = transform.position;
			cacheVec.y = Mathf.Clamp(cacheVec.y, camBottom, camTop);
			
			//Reduce ball speed
			speed = Mathf.Clamp(speed - .5f, 0, MAX_SPEED);
			if (speed == 0)
			{
				moving = false;
				club.ResetPos();
				Debug.Log("Score: " + score);
			}
		}
	}
	
	
	public void Move(float power, float direction)
	{
		moving = true;
		this.direction = direction;
		score += 5;
		speed = Mathf.Clamp(3 * power, 0, MAX_SPEED);
	}
}
