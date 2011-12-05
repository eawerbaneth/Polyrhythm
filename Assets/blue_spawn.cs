using UnityEngine;
using System.Collections;

public class blue_spawn : MonoBehaviour {
	
	public float spawnChance = 0.005f;
	//public int lane;
	public Vector3 spawnPlace = new Vector3 (5.32399f, 1f, -0.18f);
	public bluePaint bpPrefab;
	public float x = 0;

	/* Use this for initialization
	void Start () {
		
	}*/
	
	// Update is called once per frame
	void Update () {
		
		if(Random.value < spawnChance && bpPrefab)
		{
			x = Random.Range(0,100);
			
			if(x%2 == 0)
			{
				spawnPlace = new Vector3(5.32399f, 1f, -0.18f);
				Vector3 pos1 = new Vector3(5.32399f, 1f, -0.18f);
			
				bluePaint bp = (bluePaint)Instantiate(bpPrefab);
				bp.transform.position = spawnPlace;
			
				bp.transform.parent = transform;
			}
			else if(x%3 == 0)
			{
				spawnPlace = new Vector3(5.32399f, 1f, 0f);
				Vector3 pos2 = new Vector3(5.32399f, 1f, 0f);
			
				bluePaint bp = (bluePaint)Instantiate(bpPrefab);
				bp.transform.position = spawnPlace;
			
				bp.transform.parent = transform;
			}
			else if(x%5 == 0)
			{
				spawnPlace = new Vector3(5.32399f, 1f, 0.18f);
				Vector3 pos3 = new Vector3(5.32399f, 1f, 0.18f);
			
				bluePaint bp = (bluePaint)Instantiate(bpPrefab);
				bp.transform.position = spawnPlace;
			
				bp.transform.parent = transform;
			}
		}
		
	}
}
