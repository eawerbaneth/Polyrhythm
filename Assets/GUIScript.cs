using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {
    public Rect lifeBarRect;
    public Rect lifeBarLabelRect;
    public Rect lifeBarBackgroundRect;
    public Texture2D greensquare;
    public Texture2D redsquare;
    private static GUIScript instance;
    
    public float value = 50.0f;
    private float LifeBarWidth;
    private float LifeBarHeight;
    
    public float space_gain;
    public float static_drain;
    
    public float height_ratio;
    public float from_bottom_gap;
    public float beats_per_second;
    public float counter = 0;

    // Use this for initialization
    void Start(){
        Application.targetFrameRate = 60;
        instance = this;
        this.LifeBarWidth = Screen.width;
        this.LifeBarHeight = Screen.height * this.height_ratio;
        this.lifeBarRect.height = this.LifeBarHeight;
        this.lifeBarBackgroundRect.height = this.LifeBarHeight;
        this.lifeBarBackgroundRect.width = LifeBarWidth;
        this.lifeBarBackgroundRect.y = Screen.height - (Screen.height * this.height_ratio)
                                                     - from_bottom_gap;
        this.lifeBarRect.y = Screen.height - (Screen.height * this.height_ratio)
                                           - from_bottom_gap;
    }
    
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("space"))
            this.value = this.value + this.space_gain;
            
        this.value = this.value - ((Time.deltaTime * this.space_gain) * beats_per_second);            
        this.lifeBarRect.width = LifeBarWidth * (this.value / 100);
    
    }
    void OnGUI() {
        GUI.DrawTexture(lifeBarBackgroundRect, redsquare);
        GUI.DrawTexture(lifeBarRect, greensquare);
    }
}