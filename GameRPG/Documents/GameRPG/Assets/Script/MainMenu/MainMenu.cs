using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 150, 200, 200), "Menu");

        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 100, 100, 25), "Play"))
        {
            Application.LoadLevel("idontknow");
        }

        //if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 25), "Settings"))
        //{
            
        //}

        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2, 100, 25), "Quit"))
        {
            Application.Quit();
        }
    }
}
