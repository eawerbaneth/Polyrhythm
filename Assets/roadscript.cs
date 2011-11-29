using UnityEngine;
using System.Collections;

public class roadscript : MonoBehaviour {
	public Vector3 startpos;
	public float halflength;
	public float speed=-.2F;
	// Use this for initialization
	void Start () {
		startpos = transform.position;
		halflength = renderer.bounds.max.x - renderer.bounds.center.x;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(speed,0,0);
		Camera camera = Camera.main;
		GameObject road2 = GameObject.Find("road2");
		Vector3 viewPos = camera.WorldToViewportPoint(renderer.bounds.max);
		if(viewPos.y<0)//viewPos.y because it becomes y when converted to viewportPoint
			transform.position= new Vector3(road2.renderer.bounds.max.x + halflength, startpos.y, startpos.z);
	}
}
