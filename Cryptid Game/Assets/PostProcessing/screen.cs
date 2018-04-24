using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class screen : MonoBehaviour {

	Texture2D screenCap, screenCap1, screenCap2, screenCap3, screenCap4;
	
	Texture2D border;
	public int camFull = 0;
	public Camera cam;
	bool shot = false;

	// Use this for initialization
	void Start () {
		screenCap = new Texture2D(1280, 720, TextureFormat.RGB24, false);
		screenCap1 = new Texture2D(1280, 720, TextureFormat.RGB24, false);
		screenCap2= new Texture2D(1280, 720, TextureFormat.RGB24, false);
		screenCap3 = new Texture2D(1280, 720, TextureFormat.RGB24, false);
		screenCap4 = new Texture2D(1280, 720, TextureFormat.RGB24, false);
// 1
		//border = new Texture2D(200, 200, TextureFormat.ARGB32, false); // 2
		border.Apply();
	}
    
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Mouse0)){ // 3
			StartCoroutine("Capture");
			//ScreenCapture.CaptureScreenshot("photo1.png");
			camFull += 1;
			//Capture();
		}
	}

	void OnGUI(){
		GUI.DrawTexture(new Rect(200, 100, 300, 2), border, ScaleMode.StretchToFill); // top
		GUI.DrawTexture(new Rect(200, 300, 300, 2), border, ScaleMode.StretchToFill); // bottom
		GUI.DrawTexture(new Rect(200, 100, 2, 200), border, ScaleMode.StretchToFill); // left
		GUI.DrawTexture(new Rect(500, 100, 2, 200), border, ScaleMode.StretchToFill); // right

		if(shot && camFull >= 1){
			GUI.DrawTexture(new Rect(50, 50, 100, 60), screenCap, ScaleMode.StretchToFill);
		}
		
		if(shot && camFull >= 2){
			GUI.DrawTexture(new Rect(50, 140, 100, 60), screenCap1, ScaleMode.StretchToFill);
		}
	}

	IEnumerator Capture(){
		yield return new WaitForEndOfFrame();
		if (camFull == 1)
		{
			screenCap.ReadPixels(new Rect(0, 0, 1280, 720), 0, 0);
		}
		if (camFull == 2)
		{
			screenCap1.ReadPixels(new Rect(0, 0, 1280, 720), 0, 0);
		}

		if (camFull == 3)
		{
			screenCap2.ReadPixels(new Rect(0,0, 1280, 720),0,0 );
			
		}

		screenCap.Apply();
		// Encode texture into PNG
		byte[] bytes = screenCap.EncodeToPNG();
		//Object.Destroy(screenCap);

		// For testing purposes, also write to a file in the project folder
		File.WriteAllBytes(Application.dataPath + "SavedScreen.png", bytes);
		shot = true;
	}

}
