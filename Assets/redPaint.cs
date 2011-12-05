using UnityEngine;
using System.Collections;

public class redPaint : MonoBehaviour {
	
	private player_class thePlayer;
	public float dist = 0.01f;

	// Use this for initialization
	void Start () {
<<<<<<< HEAD
		GameObject temp = GameObject.Find("player_prefab");
		thePlayer = temp.GetComponent<player_class>();
=======
		//GameObject temp = GameObject.Find("player_prefab");
		//thePlayer = temp.GetComponent<player_class>();
>>>>>>> 0a6da2bf3a4e0eca0386e1dec8eb3c915ba3e8e0
	}
	
	// Update is called once per frame
	void Update () {
	
		if(transform.position.y <= 0)
		{
			
			//SPLATTER ANIMATION
			Destroy(gameObject);
			
		}
<<<<<<< HEAD
		else if((thePlayer.color == "red") && ((thePlayer.transform.position.z > 0) && ((thePlayer.transform.position.z - 1) < 0) && (transform.position.z == 0)))
		{
			if(transform.position.x <= (thePlayer.transform.position.x + dist))
			{
				Destroy(gameObject);
			}
		}
		else if((thePlayer.color == "red") && ((thePlayer.transform.position.z > 0) && ((thePlayer.transform.position.z -1) > 0) && (transform.position.z > 0)))
		{
			if(transform.position.x <= (thePlayer.transform.position.x + dist))
			{
				Destroy(gameObject);
			}
		}
		else if((thePlayer.color == "red") && (thePlayer.transform.position.z < 0) && (transform.position.z < 0))
		{
			if(transform.position.x <= (thePlayer.transform.position.x + dist))
			{
				Destroy(gameObject);
			}
		}
=======
		
		//if(thePlayer.color == "red" && )
		//{
			
		//}
>>>>>>> 0a6da2bf3a4e0eca0386e1dec8eb3c915ba3e8e0

		
	}
}
