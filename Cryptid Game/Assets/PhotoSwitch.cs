using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoSwitch : MonoBehaviour {
    public Camera Playercam;
    public Camera Photocam;
	// Use this for initialization
	void Start () {
		Photocam.enabled = false;
		Playercam.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E)){
		Photocam.enabled = true;
		Playercam.enabled = false;
		
		}
		
		if(Input.GetKeyDown(KeyCode.Q)){
			Photocam.enabled = false;
			Playercam.enabled = true;
		
		}
	}
}
