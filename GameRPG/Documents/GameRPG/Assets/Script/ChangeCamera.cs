using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour {

	public GameObject cam3d;
	public GameObject camMap;
	public bool whichcam = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.M)){
			if(whichcam == false)
				whichcam = true;
			else if(whichcam == true)
				whichcam = false;
		}
		
		if(whichcam == false){
			cam3d.active = true;
			camMap.active = false;
		}

		if(whichcam == true){
			cam3d.active = false;
			camMap.active = true;
		}
			
	}
}
