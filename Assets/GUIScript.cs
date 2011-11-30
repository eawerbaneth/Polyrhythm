using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {
    public Rect lifeBarRect;
    public Rect lifeBarBackgroundRect;
    public Rect glimmerRect;
    public Texture2D greensquare;
    public Texture2D redsquare;
    public Texture2D glimmerTexture;
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
    
    private float glimmer_start_time = 0;
    private float glimmer_counter = 0;
    private float glimmer_active_time = 0;
    

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
        this.glimmerRect.width = LifeBarWidth;
        this.glimmerRect.height = LifeBarHeight * 1.2f;
        this.glimmerRect.y =  Screen.height - (Screen.height * this.height_ratio)
                                            - from_bottom_gap
                                            - (LifeBarHeight * 0.1f);
    }
    
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("space"))
            this.value = this.value + this.space_gain;
            
        this.value = this.value - ((Time.deltaTime * this.space_gain) * beats_per_second);            
        this.lifeBarRect.width = LifeBarWidth * (this.value / 100);
        
        this.glimmer_counter = 1.0f / beats_per_second;
        this.glimmer_active_time = glimmer_counter * 0.4f;
        
        if(Time.time >= this.glimmer_counter + this.glimmer_start_time)
            this.glimmer_start_time = Time.time;
    
    }
    void OnGUI() {
        if(Time.time < this.glimmer_start_time + this.glimmer_active_time)
            GUI.DrawTexture(glimmerRect, glimmerTexture);
        
        GUI.DrawTexture(lifeBarBackgroundRect, redsquare);
        GUI.DrawTexture(lifeBarRect, greensquare);
    }
}