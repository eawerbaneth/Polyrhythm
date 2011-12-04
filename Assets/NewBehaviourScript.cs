using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnGUI () {
        if (GUI.Button (new Rect (20,70,80,20), "Next Level")) {
            Application.LoadLevel("beth_scene_mammoth"); 

        }
    }
}
