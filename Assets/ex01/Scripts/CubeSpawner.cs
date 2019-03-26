using UnityEngine;

public class CubeSpawner : MonoBehaviour
{

	public GameObject prefab;

	public float spawnInterval;
	private float lastSpawnTime;
	
	// Use this for initialization
	void Start ()
	{
		lastSpawnTime = spawnInterval;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > lastSpawnTime + spawnInterval)
		{
			lastSpawnTime  = Time.time;
			Instantiate(prefab,transform.position, Quaternion.identity);
		}
	}
}
