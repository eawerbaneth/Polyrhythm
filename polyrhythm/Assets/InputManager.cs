using UnityEngine;
using System.Collections;

public struct key_pair{
	public string name;
	public float time;
}

public class InputManager : MonoBehaviour {
	private static InputManager instance;
	public Queue keyQueue;
	public string test;
	
	public static InputManager get{
		get{
			if(!instance)
				Debug.LogError("No InputManager in scene");
			return instance;
		}
	}
	
	private string[] keys = new string[]{"red", "yellow", "blue", 
		"green", "foot_pedal", "start", "back"};
	
	
	void Awake(){
		instance = this;
		keyQueue = new Queue();
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach (string key in keys){
			if(Input.GetButtonDown(key)){
				key_pair temp;
				temp.name = key;
				temp.time = Time.time;			
				keyQueue.Enqueue(temp);
				test = key;
			}
		}
	}
	
	public key_pair GetNextKey(){
		return (key_pair)keyQueue.Dequeue();
	}
	
	public bool HasKeys(){
		return keyQueue.Count > 0;
	}
}
