﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralleax : MonoBehaviour {
    public GameObject poi;//主角飞船
    public GameObject[] panels;//滚动的前景画面
    public float scrollSpeed = -30f;
    public float motionMult = 0.25f;
    private float panelHt;//每个前景画面的高度
    private float depth;//前景画面的深度

	void Start () {
        panelHt = panels[0].transform.localScale.y;
        depth = panels[0].transform.position.z;
        //设置前面画面的初始位置
        panels[0].transform.position = new Vector3(0, 0, depth);
        panels[1].transform.position = new Vector3(0, panelHt, depth);
	}
	
	void Update () {
        float tY, tX = 0;
        tY = Time.time * scrollSpeed % panelHt + (panelHt * 0.5f);
        if (poi!=null)
        {
            tX = -poi.transform.position.x * motionMult;
        }
        //设置panels[0]的位置
        panels[0].transform.position = new Vector3(tX, tY, depth);
        //在必要的时候设置panels[1]的位置，使星空背景连续
        if (tY>=0)
        {
            panels[1].transform.position = new Vector3(tX, tY - panelHt, depth);
        }
        else
        {
            panels[1].transform.position = new Vector3(tX, tY + panelHt, depth);
        }
	}
}
