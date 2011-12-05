using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class combo_master : MonoBehaviour {
	private static combo_master instance;
	public bool test_combo;
	public string seen;
	public int test_count;
	public int combo_count;
	
	public Queue output_queue;
	public List <key_pair> combo_interpreter;
	private float combo_timer;
	private float simul_timer;
	private InputManager input;
	
	
	//ADVANCED COMBOS
	private static string[] red_advanced = {"blue", "blue", "blue", "combo", "blue", "blue", "blue", "combo"};
	private static string[] blue_advanced = {"yellow", "yellow", "yellow", "yellow", "yellow", "yellow", "yellow", "yellow"};
	private static string[] yellow_advanced = {"combo", "combo", "blue", "yellow", "combo"};
	
	//REGULAR COMBOS
	private static string[] red_combo = {"blue", "combo", "blue", "combo", "blue", "combo"};
	private static string[] blue_combo = {"yellow", "yellow", "yellow", "yellow", "yellow", "yellow"};
	//private static string[] blue_combo = {"blue", "blue", "blue", "blue", "blue", "blue"};
	private static string[] yellow_combo = {"combo", "combo", "combo", "combo"};
	
	//EASY COMBOS
	private static string[] red_easy = {"blue", "yellow", "blue"};
	private static string[] blue_easy = {"yellow", "yellow", "yellow"};
	private static string[] yellow_easy = {"combo", "combo", "combo"};
	
	public static combo_master get{
		get{
			if(!instance)
				Debug.LogError("No InputManager in scene");
			return instance;
		}
	}
	
	void Awake(){
		instance = this;
		output_queue = new Queue();
		combo_interpreter = new List<key_pair>();
	}
	
	//let player_class empty out output after used up
	public void empty_output(){
		output_queue.Clear();	
	}
	
	//register combos
	public void handle_combos(){
		key_pair key;
		seen = "";
		
		while(InputManager.get.HasKeys()){
			key = InputManager.get.GetNextKey();
			if(key.name == "green" || key.name == "red"){ //|| key.name == "foot_pedal"){
				output_queue.Enqueue(key.name);
			}
			else if(key.name == "blue" || key.name == "yellow"){
				combo_interpreter.Add(key);
				seen += key.name;
			}
		}
	}
	
	//clean up list and combine simulatenous pad registers into combos
	public List <key_pair> clean_list(){
		List <key_pair> temp = new List <key_pair>();
		float cutofftime = Time.time - combo_timer;
		test_count = combo_interpreter.Count;
		
		for(int i = 0; i<combo_interpreter.Count; i++){
			//forget about input too old to be part of current combo
			if(combo_interpreter[i].time > cutofftime){
				//check to see if the next one is simultaneous with this one
				if(i<combo_interpreter.Count-1){
					if(combo_interpreter[i+1].time - combo_interpreter[i].time <= simul_timer){
						//it was simultaneous, create a combo hit for it
						key_pair combo;
						combo.name = "combo";
						combo.time = combo_interpreter[i].time;
						temp.Add(combo);
						//skip over the next thing, as we've already consumed it
						i++;
						combo_count++;
					}
					else
						temp.Add(combo_interpreter[i]);
				}
				else
					temp.Add(combo_interpreter[i]);						
			}
		}
		
		return temp;
		
	}
	
	//interpret combo_queue
	public void parse_combos(){
		//get an augmented version of list to check for combos with
		List <key_pair> temp = clean_list();
		int temp_count = temp.Count;
		
		//we have out updated list, now check for combinations
		if(temp.Count >= 6){
			//red
			int offset = 0;
			for(int i = 0; i< temp.Count-6; i++){
				for(int x = i; x<i+6; x++){
					//check to see if we have a contiguous combo
					if(temp[x].name == red_combo[offset])
						offset++;
					//if our combo breaks off, reset
					else{
						offset = 0;
						break;
					}
				}
				//check to see if we had a full combo
				if(offset!=0){
					//if we did, add the combo to our output queue
					//clear the combo from our combination interpreter
					output_queue.Enqueue("red_combo");
					Debug.Log("Red: Count is: " + temp.Count + " i is: " + i + "offset is: " + offset);
					temp.RemoveRange(i, offset);
					offset = 0;
					break;
				}
			}
		}
		if(temp.Count >= 6){
			//blue
			int offset = 0;
			for(int i = 0; i< temp.Count-6; i++){
				for(int x = i; x<i+6; x++){
					//check to see if we have a contiguous combo
					if(temp[x].name == blue_combo[offset])
						offset++;
					//if our combo breaks off, reset and move on
					else{
						offset = 0;
						break;
					}
				}
				//check to see if we had a full combo
				if(offset != 0){
					//if we did, add the combo to our output queue
					output_queue.Enqueue("blue_combo");
					//clear the combo from our combination interpreter
					Debug.Log("Blue: Count is: " + temp.Count + " i is: " + i);
					temp.RemoveRange(i, offset);
					offset = 0;
					break;
				}
			}
				
		}
		//yellow
		if(temp.Count >= 3){
			int offset = 0;
			for(int i = 0; i< temp.Count-3; i++){
				for(int x = i; x<i+2; x++){
					//check to see if we have a contiguous combo
					if(temp[x].name == yellow_combo[offset])
						offset++;
					//if our combo breaks off, reset
					else{
						offset = 0;
						break;
					}
				}
				//check to see if we had a full combo
				if(offset != 0){
					//if we did, add the combo to our output queue
					output_queue.Enqueue("yellow_combo");
					//clear the combo from our combination interpreter
					Debug.Log("Yellow: Count is: " + temp.Count + " i is: " + i);
					temp.RemoveRange(i, offset);
					offset = 0;
					break;
				}
			}
			
		}
		
		if(temp.Count < temp_count)
			Debug.Log("temp count changed: " + temp_count + "->" + temp.Count);
		
		combo_interpreter = temp;
		
	}
	
	// Use this for initialization
	void Start () {
		simul_timer = 0.05f;
		combo_timer = 7;
		combo_count = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		//recieve new input
		handle_combos();
		parse_combos();
	
	}
}
