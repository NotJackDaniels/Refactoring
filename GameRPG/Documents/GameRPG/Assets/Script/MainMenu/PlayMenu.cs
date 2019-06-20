using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMenu : MonoBehaviour {

    private bool isPaused = false;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            if (isPaused) Time.timeScale = 1;
            Cursor.visible = !Cursor.visible;
            isPaused = !isPaused;
        }
    }

    void OnGUI()
    {
        if (isPaused)
        {
            Time.timeScale = 0;

            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 150, 200, 200), "Menu");

            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 100, 100, 25), "Continue"))
            {
                Cursor.visible = !Cursor.visible;
                isPaused = !isPaused;
                Time.timeScale = 1;
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
}
