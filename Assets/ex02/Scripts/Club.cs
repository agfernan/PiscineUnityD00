using UnityEngine;

public class Club : MonoBehaviour
{

	public Ball ball;
	public Transform hole;
	private float power;
	private float direction;
	private Vector3 cacheVec;

	private void Start()
	{
		direction = 1;
	}

	public void ResetPos()
	{
		//Change club direction
		direction = ball.transform.position.y > hole.position.y ? -1 : 1;
		cacheVec = transform.localScale;
		cacheVec.y = direction;
		transform.localScale = cacheVec;
		
		//Set club pos near ball
		cacheVec = ball.transform.position;
		cacheVec.x = transform.position.x;
		transform.position = cacheVec;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space) && ball.moving == false)
		{	
			power += 0.5f;
			transform.Translate(Vector3.down * Time.deltaTime * direction * power);
		}
		else if (power != 0)
		{
			ResetPos();
			ball.Move(power,direction);
			power = 0;
		}
	}
}
