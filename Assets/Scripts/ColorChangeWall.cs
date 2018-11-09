using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeWall : MonoBehaviour {
		    public GameObject player;
	// Use this for initialization
	void Start () {
	        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0f, 12f * player.GetComponent<Player>().speedFactor * Time.deltaTime, 0f));
	}
}
