using UnityEngine;
using System.Collections;

public class yellow_spawn : MonoBehaviour {
	
	public float spawnChance = 0.005f;
	public int lane;
	public Vector3 spawnPlace = new Vector3 (5.32399f, 1f, -0.18f);
	public yellowPaint ypPrefab;
	public float x = 0;
	

	/* Use this for initialization
	void Start () {
		
	}*/
	void Start(){
		
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if(Random.value < spawnChance && ypPrefab)
		{
			x = Random.Range(0,100);
			
			if(x%2 == 0)
			{
				spawnPlace = new Vector3(5.32399f, 1f, -0.18f);
				Vector3 pos1 = new Vector3(5.32399f, 1f, -0.18f);
			
				yellowPaint yp = (yellowPaint)Instantiate(ypPrefab);
				yp.transform.position = spawnPlace;
			
				yp.transform.parent = transform;
				
				lane = 1;
			}
			else if(x%3 == 0)
			{
				spawnPlace = new Vector3(5.32399f, 1f, 0f);
				Vector3 pos2 = new Vector3(5.32399f, 1f, 0f);
			
				yellowPaint yp = (yellowPaint)Instantiate(ypPrefab);
				yp.transform.position = spawnPlace;
			
				yp.transform.parent = transform;
				
				lane = 2;
			}
			else if(x%5 == 0)
			{
				spawnPlace = new Vector3(5.32399f, 1f, 0.18f);
				Vector3 pos3 = new Vector3(5.32399f, 1f, 0.18f);
			
				yellowPaint yp = (yellowPaint)Instantiate(ypPrefab);
				yp.transform.position = spawnPlace;
			
				yp.transform.parent = transform;
				
				lane = 3;
			}
		}
<<<<<<< HEAD
		
		
		
=======
		*/
>>>>>>> 0a6da2bf3a4e0eca0386e1dec8eb3c915ba3e8e0
	}
}
