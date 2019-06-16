using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trade : MonoBehaviour {
    public GameObject tradeWindow;
    public float seeDistance;
    public float currentDistance;
    private Transform target;
    // Use this for initialization
    void Start () {
        target = GameObject.FindWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
        currentDistance = Vector3.Distance(transform.position, target.position);
        if (Input.GetKeyDown(KeyCode.B) && currentDistance <= seeDistance)
        {
            Time.timeScale = 0;
            tradeWindow.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && currentDistance <= seeDistance)
        {
            tradeWindow.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
