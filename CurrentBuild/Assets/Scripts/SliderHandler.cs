using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SliderHandler : MonoBehaviour {

    public Slider sl;
    public Image img;
    public AudioSource[] auso;
    bool on = false;
    public float up, down, left, right;
    float mosX, mosY;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(on && Input.GetMouseButtonDown(0))
        {
            Off();
        }
	}

    public void SliderOn()
    {
        sl.enabled = true;
        img.enabled = true;
        on = true;
    }

    public void VolumeChange(float s)
    {
        for(int c=0;c<auso.Length;c++)
            auso[c].volume = s;
    }
    
    public void Off()
    {
        mosX = Input.mousePosition.x / Screen.width;
        mosY = Input.mousePosition.y / Screen.height;
        if (mosX < left || mosX > right || mosY < down || mosY > up)
        {
            sl.enabled = false;
            img.enabled = false;
            on = false;
        }

    }
}
