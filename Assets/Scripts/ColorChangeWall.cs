﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0f, 0.3f, 0f));
	}
}
