﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trade : MonoBehaviour {
    public GameObject tradeWindow;
    public float seeDistance;
    public float currentDistance;
    private Transform target;
    public TraderItems traderItems;
    public Transform ItemHab;
    public GameObject ItemVisualPrefab;
    bool isLocked;
    bool invOn = false;


    // Use this for initialization

    void SetCursorLock(bool isLocked)
    {
        this.isLocked = isLocked;
        Screen.lockCursor = isLocked;
        Cursor.visible = !isLocked;
    }
        
    public void AddItem(Item item)
    {
        GameObject newItem = Instantiate(ItemVisualPrefab, Vector3.zero, Quaternion.identity, ItemHab);
        newItem.GetComponent<ItemVisual>().Init(item);
    }
    void Start () {
        tradeWindow.SetActive(false);
        target = GameObject.FindWithTag("Player").transform;
        Cursor.visible = true;
        SetCursorLock(true);
    }

    // Update is called once per frame
    void Update ()
    {
        currentDistance = Vector3.Distance(transform.position, target.position);
        if (Input.GetKeyDown(KeyCode.B) && currentDistance <= seeDistance && invOn == false)
        {
            invOn = true;
            tradeWindow.SetActive(true);
            Time.timeScale = 0;
            SetCursorLock(!isLocked);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && (currentDistance <= seeDistance) && invOn == true)
        {
            invOn = false;
            tradeWindow.SetActive(false);
            Time.timeScale = 1;
            SetCursorLock(!isLocked);
        }
    }
}
