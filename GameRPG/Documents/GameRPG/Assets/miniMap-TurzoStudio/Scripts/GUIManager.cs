﻿using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

	public RenderTexture MiniMapTexture;
	public Material MiniMapMaterial;
	//private float offset;


	//// Use this for initialization
	//void Awake () {
	//	offset = 10;	
	//}
	
	// Update is called once per frame
	void OnGUI() {		
			Rect Map_Rectangle = new Rect (0.80f * Screen.width, 0.03f * Screen.height,
				                    0.18f * Screen.width, 0.35f * Screen.height);

			if (Event.current.type == EventType.Repaint) {

				Graphics.DrawTexture (Map_Rectangle, MiniMapTexture, MiniMapMaterial);
			
			}

		
	}
}
