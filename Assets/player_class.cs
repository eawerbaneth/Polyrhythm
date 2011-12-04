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
	public GameObject bino;
	public float reflected_bps;
	
	private GUIScript gui_instance;
	
	//textures	
	private Texture red_tex ;
	private Texture blue_tex ;
	private Texture white_tex ;
	private Texture yellow_tex ;
	
	//sliding around stuff
	private bool is_tweening;
	private float remaining_tween_z;
	
	private void tweening(){
		Vector3 trans_coords = transform.forward;
		//we are moving right
		if(remaining_tween_z > 0){
			trans_coords.z = 0.15f * Time.deltaTime * 1.8f;
			if(trans_coords.z > remaining_tween_z)
				trans_coords.z = remaining_tween_z;
		}
		//we are moving left
		else{
			trans_coords.z = -0.15f * Time.deltaTime * 1.8f;
			if(trans_coords.z < remaining_tween_z)
				trans_coords.z = remaining_tween_z;
		}
		
		transform.Translate(trans_coords);
		remaining_tween_z -= trans_coords.z;
		
	}
	
		
	//change lanes: true is up, false is down
	public void change_lane(bool direction){
		
		//Vector3 trans_coords = transform.forward;
		//trans_coords.z = 0.15f;
		
		if(direction && lane < 2){
			lane++;
			remaining_tween_z += 0.15f;
		}
		else if(!direction && lane > 0){
			lane--;
			remaining_tween_z -= 0.15f;
		}
		
	}
	
	
	public void animation_update(){
		GameObject guibar = GameObject.Find("GUI - Bar");
		
		gui_instance = guibar.GetComponent<GUIScript>();
		
		float bps = gui_instance.beats_per_second;
		reflected_bps = bps;
		
		bino.animation["running"].speed = 1.6f * bps;
		
	}
	
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
		if(color != "none")
			bino.animation.Play("powerup");
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
		
		bino = GameObject.Find("bino");
		bino.animation.Stop();
		bino.animation.Play("running");
		bino.animation["running"].speed = 1.6f;
		
		bino.animation.wrapMode = WrapMode.Loop;
		
		remaining_tween_z = 0;
	}
	
	
	// Use this for initialization
	void Start () {
		//Debug.Log(name);
	}
	
	// Update is called once per frame
	void Update () {
		receive_input();
		animation_update();
		if(remaining_tween_z != 0)
			tweening();
	}
}
