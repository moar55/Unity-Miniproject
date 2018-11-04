using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public GameObject player;
	
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0f,0f,-0.3f * player.GetComponent<Player>().speedFactor));

        if (Vector3.Distance(transform.position, player.transform.position) > 18)
            Destroy(gameObject);
	}


}
