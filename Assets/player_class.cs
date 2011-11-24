using UnityEngine;
using System.Collections;

//red 2
//yellow 4
//blue 3
//green 1
//foot pedal 5
//start 8
//back 7

public class player_class : MonoBehaviour {
	
	public int lane;
	private combo_master input_feed;
	public string color;
	public float cooldown;
	private CharacterController controller;
	public Vector3 test;

	
	public void receive_input(){
		
		cooldown -= Time.deltaTime;
		if(cooldown  < 0)
			cooldown = 0;
		
		input_feed = GetComponent<combo_master>();
		Queue input = input_feed.output_queue;
		
		foreach(string key in input){
			if(key == "green")
				change_lane(true);
			else if (key == "red")
				change_lane(false);
			//TODO: ADD ANIMATIONS FOR COLOR CHANGE
			else if (key == "red_combo"){
				color = "red";
				cooldown = 3;
			}
			else if (key == "blue_combo"){
				color = "blue";
				cooldown = 3;
			}
			else if (key=="yellow_combo"){
				color = "yellow";
				cooldown = 3;
			}
		}
		
		//clear out output
		input_feed.empty_output();
		
		//reset the cooldown
		if(cooldown == 0)
			color = "none";
		
	}
	
	//change lanes: true is up, false is down
	public void change_lane(bool direction){
		//NEED TO ADD ANIMATIONS IN HERE
		
		//Vector3 move_coords = new Vector3(0, 0, 0);
		Vector3 trans_coords = transform.forward;
		test = trans_coords;
		
		//Vector3 trans_coords = new Vector3(transform.position.x,
		//       transform.position.y, transform.position.z);
		
		if(direction && lane < 2){
			lane++;
			//trans_coords.z += 1;
			trans_coords = -trans_coords;
			transform.Translate(trans_coords);
		}
		else if(!direction && lane > 0){
			lane--;
			//trans_coords.z -= 1;
			transform.Translate(trans_coords);
		}
		
	}
	
	void Awake(){
		lane = 1;
		color = "none";
		cooldown = 0;
	}
	
	
	// Use this for initialization
	void Start () {		
	}
	
	// Update is called once per frame
	void Update () {
		receive_input();
		
	
	}
}
