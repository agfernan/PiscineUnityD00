using System.Net.Mime;
using UnityEngine;

public class Balloon : MonoBehaviour
{
	public float maxBreath;
	private float breath;
	private bool recovering;
	public float transformRatio;
	
	// Use this for initialization
	void Start ()
	{
		breath = maxBreath;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (transform.localScale.x >= 10)
		{
			Debug.Log("Balloon life time: ${time}s".Replace("${time}", Mathf.RoundToInt(Time.time).ToString()));
			Destroy(gameObject);
		}
		
		if (!recovering)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				breath -= 100 * Time.deltaTime;
				transform.localScale += Vector3.one * 10 * transformRatio * Time.deltaTime;
			}
		}
		else if (breath >= maxBreath)
			recovering = false;
		
		breath += 10 * Time.deltaTime;
		breath = breath > maxBreath ? maxBreath : breath;
		if (breath <= 0)
		{
			breath = 0;
			recovering = true;
		}
		
		//Handle balloon scale reducing and negative scale
		transform.localScale -= Vector3.one * transformRatio * Time.deltaTime;
		if (transform.localScale.x < .1f)
			transform.localScale = Vector3.one * .1f;
	}
}
