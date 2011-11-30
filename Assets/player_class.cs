using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
	public List <string> feet;
	public GameObject player;
	
	//textures	
	public Texture red_tex ;
	public Texture blue_tex ;
	public Texture white_tex ;
	public Texture yellow_tex ;

	
	public void apply_texture(){
		GameObject []bodyparts = GameObject.FindGameObjectsWithTag("Player");
		foreach(GameObject bodypart in bodyparts){
			if(color == "none")
				bodypart.renderer.material.mainTexture = white_tex;	
			else if(color == "blue")
				bodypart.renderer.material.mainTexture = blue_tex;	
			else if(color == "red")
				bodypart.renderer.material.mainTexture = red_tex;	
			if(color == "yellow")
				bodypart.renderer.material.mainTexture = yellow_tex;	
				
		}
		
	}
	
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
			else if (key == "foot_pedal")
				feet.Add(key);
			//TODO: ADD ANIMATIONS FOR COLOR CHANGE
			else if (key == "red_combo"){
				color = "red";
				cooldown = 3;
				apply_texture();
			}
			else if (key == "blue_combo"){
				color = "blue";
				cooldown = 3;
				apply_texture();
			}
			else if (key=="yellow_combo"){
				color = "yellow";
				cooldown = 3;
				apply_texture();
			}
		}
		
		//clear out output
		input_feed.empty_output();
		
		//reset the cooldown
		if(cooldown == 0){
			color = "none";
			apply_texture();
		}
		
	}
	
	//change lanes: true is up, false is down
	public void change_lane(bool direction){
		//NEED TO ADD ANIMATIONS IN HERE
		
		Vector3 trans_coords = transform.forward;
		trans_coords.z = 0.15f;
		
		if(direction && lane < 2){
			lane++;
			transform.Translate(trans_coords);
		}
		else if(!direction && lane > 0){
			lane--;
			trans_coords = -trans_coords;
			transform.Translate(trans_coords);
		}
		
	}
	
	void Awake(){
		lane = 1;
		color = "none";
		cooldown = 0;
		feet = new List<string>();
		player = GameObject.Find("player_prefab");
		
		red_tex = Resources.Load("red") as Texture;
		blue_tex = Resources.Load("blue") as Texture;
		white_tex = Resources.Load("white") as Texture;
		yellow_tex = Resources.Load("yellow") as Texture;
		
	}
	
	
	// Use this for initialization
	void Start () {		
	}
	
	// Update is called once per frame
	void Update () {
		receive_input();
		
	
	}
}
