using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDialogs : MonoBehaviour {
    public bool EndDialogs;
    public GameObject Dialog1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ( EndDialogs == true)
        {
            Time.timeScale = 1;
            Dialog1.SetActive(false);
        }
	}

    private void OnTriggerEnter(Collider col)
    {
        if ( col.tag == "Player")
        {
            Time.timeScale = 0;
            Dialog1.SetActive(true);
        }
    }

}
